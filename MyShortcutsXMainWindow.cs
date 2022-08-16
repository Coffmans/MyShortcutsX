using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyShortcutsX
{
    public partial class MyShortcutsXMainWindow : Form
    {
        private enum Mode
        {
            AddGroup,
            ModGroup,
            DelGroup,
            AddShortcut,
            ModShortcut,
            DelShortcut,
            CopyShortcut
        }

        private enum ShortcutType
        {
            Folder,
            Exe
        }

        private ComboboxItem _modGroup = new ComboboxItem();
        private int _groupIndex = -1;
        private Mode _mode;

        private MyShortcutsXData? _myShortCutData = new MyShortcutsXData();

        private List<MyShortcutsXDataGroup> _myGroups = new List<MyShortcutsXDataGroup>();
        private List<MyShortcutsXDataShortcut> _myShortcuts = new List<MyShortcutsXDataShortcut>();

        public MyShortcutsXMainWindow()
        {
            InitializeComponent();
        }

        #region UI Event Handlers

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            AddGroup();
        }

        private void btnModGroup_Click(object sender, EventArgs e)
        {
            EditGroup();
        }

        private void btnDelGroup_Click(object sender, EventArgs e)
        {
            DeleteGroup();
        }

        private void AddShortcut_Click(object sender, EventArgs e)
        {
            AddShortcut();
        }

        private void btnModShortcut_Click(object sender, EventArgs e)
        {
            EditShortcut();
        }

        private void btnDelShortcut_Click(object sender, EventArgs e)
        {
            DeleteShortCut();
        }

        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGroup();
        }

        private void editGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditGroup();
        }

        private void deleteGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteGroup();
        }

        private void copyShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyShortcut();
        }

        private void addShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearFields();
            EnableDisableShortcutControls(true);
            btnSaveShortcut.Enabled = true;
            cbGroupName.Enabled = true;
            _mode = Mode.AddShortcut;

            rbExe.Checked = true;
        }

        private void editShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditShortcut();
        }

        private void deleteShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteShortCut();
        }

        private void btnSaveShortcut_Click(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case Mode.AddGroup:
                    {
                        MyShortcutsXDataGroup newGroup = new MyShortcutsXDataGroup
                        {
                            Guid = Guid.NewGuid(),
                            Name = (string)cbGroupName.Text
                        };
                        if (AddNewGroupToTree(newGroup))
                        {
                            _myGroups.Add(newGroup);
                            if (_myShortCutData != null)
                            {
                                _myShortCutData.Groups = _myGroups.ToArray();
                                ReadWriteShortcuts.SaveShortCutsData(_myShortCutData);
                                ComboboxItem item = new ComboboxItem
                                {
                                    Text = newGroup.Name,
                                    Value = newGroup.Guid
                                };
                                cbGroupName.Items.Add(item);
                            }

                        }

                    }
                    break;
                case Mode.AddShortcut:
                    {
                        MyShortcutsXDataShortcut newShortcut = new MyShortcutsXDataShortcut
                        {
                            Guid = Guid.NewGuid(),
                            Name = txtFriendlyName.Text,
                            Parameters = txtParameters.Text,
                            Path = txtEXEPath.Text
                        };

                        newShortcut.Type = rbExe.Checked ? ShortcutType.Exe : ShortcutType.Folder;


                        ComboboxItem cbSelectedItem = (ComboboxItem)cbGroupName.SelectedItem;
                        newShortcut.GroupGuid = (Guid)cbSelectedItem.Value;

                        foreach (var group in _myGroups)
                        {
                            if (group.Name == (string)cbSelectedItem.Text)
                            {
                                newShortcut.GroupGuid = (Guid)group.Guid;
                                _myShortcuts.Add(newShortcut);
                                if (AddNewShortcutToTree(newShortcut))
                                {
                                    if (_myShortCutData != null)
                                    {
                                        _myShortCutData.Shortcuts = _myShortcuts.ToArray();
                                        ReadWriteShortcuts.SaveShortCutsData(_myShortCutData);
                                    }
                                }

                                break;
                            }
                        }


                    }
                    break;
                case Mode.DelGroup:
                    break;
                case Mode.DelShortcut:
                    {


                    }
                    break;
                case Mode.ModGroup:
                    {
                        {
                            MyShortcutsXDataGroup modShortcut = new MyShortcutsXDataGroup
                            {
                                Name = _modGroup.Text,
                                Guid = (Guid)_modGroup.Value
                            };

                            foreach (var group in _myGroups)
                            {
                                if ((Guid)_modGroup.Value == group.Guid)
                                {
                                    group.Name = cbGroupName.Text;

                                    ModGroupToTree(group);
                                    if (_myShortCutData != null)
                                    {
                                        _myShortCutData.Groups = _myGroups.ToArray();
                                        ReadWriteShortcuts.SaveShortCutsData(_myShortCutData);
                                        ComboboxItem item = new ComboboxItem();
                                        item.Text = cbGroupName.Text;
                                        item.Value = group.Guid;
                                        cbGroupName.Items[_groupIndex] = item;
                                    }

                                    break;
                                }
                            }

                        }
                    }

                    break;
                case Mode.ModShortcut:
                    {
                        MyShortcutsXDataShortcut modShortcut = new MyShortcutsXDataShortcut
                        {
                            Name = txtFriendlyName.Text,
                            Parameters = txtParameters.Text,
                            Path = txtEXEPath.Text
                        };

                        TreeNode shortcutNode = treeShortcuts.SelectedNode;
                        TreeNodeTypeAndGuid typeAndGuid = (TreeNodeTypeAndGuid)shortcutNode.Tag;

                        foreach (var shortcut in _myShortcuts)
                        {
                            if ((Guid)typeAndGuid.Guid == shortcut.Guid)
                            {
                                Guid originalGroupGuid = (Guid)shortcut.GroupGuid;

                                shortcut.Name = modShortcut.Name;
                                shortcut.Parameters = modShortcut.Parameters;
                                shortcut.Path = modShortcut.Path;

                                ComboboxItem cbItem = (ComboboxItem)cbGroupName.SelectedItem;

                                bool groupChanged = false;
                                if (shortcut.GroupGuid != (Guid)cbItem.Value)
                                {
                                    foreach (var group in _myGroups)
                                    {
                                        if (group.Guid == (Guid)cbItem.Value)
                                        {
                                            shortcut.GroupGuid = (Guid)group.Guid;
                                            groupChanged = true;
                                            break;
                                        }
                                    }
                                }

                                ModShortcutToTree(shortcut, originalGroupGuid, groupChanged);
                                if (_myShortCutData != null)
                                {
                                    _myShortCutData.Shortcuts = _myShortcuts.ToArray();
                                    ReadWriteShortcuts.SaveShortCutsData(_myShortCutData);
                                }
                                break;
                            }
                        }
                    }

                    break;
                default:
                    break;
            }


        }

        private void treeShortcuts_DoubleClick(object sender, EventArgs e)
        {

            btnSaveShortcut.Enabled = true;

            TreeNode node = treeShortcuts.SelectedNode;
            if (node != null)
            {
                TreeNodeTypeAndGuid typeNode = (TreeNodeTypeAndGuid)node.Tag;
                if (typeNode.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                {
                    EnableDisableShortcutControls(true);
                    cbGroupName.Enabled = true;
                    groupBoxType.Enabled = false;
                    btnSaveShortcut.Enabled = true;
                    _mode = Mode.ModShortcut;

                    MyShortcutsXDataShortcut shortcut = _myShortcuts.First(s => s.Guid == (Guid)typeNode.Guid);
                    txtFriendlyName.Text = shortcut.Name;
                    txtEXEPath.Text = shortcut.Path;
                    txtParameters.Text = shortcut.Parameters;
                    rbExe.Checked = ((ShortcutType)shortcut.Type == ShortcutType.Exe) ? true : false;
                    ClearFields();
                }
                else
                {
                    ClearFields();
                    EnableDisableShortcutControls(false);
                    cbGroupName.Enabled = true;
                    groupBoxType.Enabled = false;
                    btnSaveShortcut.Enabled = true;
                    _mode = Mode.ModGroup;
                    for (int n = 0; n < cbGroupName.Items.Count; n++)
                    {
                        ComboboxItem? cbItem = cbGroupName.Items[n] as ComboboxItem;
                        if (cbItem == null) throw new ArgumentNullException(nameof(cbItem));

                        if ((Guid)cbItem.Value == typeNode.Guid)
                        {
                            cbGroupName.SelectedIndex = n;
                        }
                    }
                }
            }
        }

        private void treeShortcuts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnSaveShortcut.Enabled = true;

            TreeNode node = treeShortcuts.SelectedNode;
            if (node != null)
            {
                TreeNodeTypeAndGuid typeNode = (TreeNodeTypeAndGuid)node.Tag;
                if (typeNode.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                {
                    ClearFields();
                    EnableDisableShortcutControls(true);
                    cbGroupName.Enabled = true;
                    groupBoxType.Enabled = false;
                    btnSaveShortcut.Enabled = true;
                    _mode = Mode.ModShortcut;

                    MyShortcutsXDataShortcut shortcut = _myShortcuts.First(s => s.Guid == (Guid)typeNode.Guid);
                    if (shortcut != null)
                    {
                        txtFriendlyName.Text = shortcut.Name;
                        txtEXEPath.Text = shortcut.Path;
                        txtParameters.Text = shortcut.Parameters;
                        rbExe.Checked = ((ShortcutType)shortcut.Type == ShortcutType.Exe) ? true : false;

                        for (int n = 0; n < cbGroupName.Items.Count; n++)
                        {
                            ComboboxItem? cbItem = cbGroupName.Items[n] as ComboboxItem;
                            if (cbItem == null) throw new ArgumentNullException(nameof(cbItem));

                            if ((Guid)cbItem.Value == shortcut.GroupGuid)
                            {
                                cbGroupName.SelectedIndex = n;
                                break;
                            }
                        }

                    }
                }
                else
                {
                    ClearFields();
                    EnableDisableShortcutControls(false);
                    cbGroupName.Enabled = true;
                    groupBoxType.Enabled = false;
                    btnSaveShortcut.Enabled = true;
                    _mode = Mode.ModGroup;
                    for (int n = 0; n < cbGroupName.Items.Count; n++)
                    {
                        ComboboxItem? cbItem = cbGroupName.Items[n] as ComboboxItem;
                        if (cbItem == null) throw new ArgumentNullException(nameof(cbItem));

                        if ((Guid)cbItem.Value == typeNode.Guid)
                        {
                            cbGroupName.SelectedIndex = n;
                            _modGroup = cbItem;
                            _groupIndex = n;
                            break;
                        }
                    }
                }
            }
        }

        private void treeShortcuts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.Shift && e.KeyCode == Keys.N)
            {
                TreeNode node = treeShortcuts.SelectedNode;
                if (node != null)
                {
                    TreeNodeTypeAndGuid typeNode = (TreeNodeTypeAndGuid)node.Tag;
                    if (typeNode.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                    {
                        AddShortcut();
                    }
                    else
                    {
                        AddGroup();
                    }
                }
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.E)
            {
                TreeNode node = treeShortcuts.SelectedNode;
                if (node != null)
                {
                    TreeNodeTypeAndGuid typeNode = (TreeNodeTypeAndGuid)node.Tag;
                    if (typeNode.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                    {
                        ClearFields();
                        EnableDisableShortcutControls(true);
                        cbGroupName.Enabled = true;
                        groupBoxType.Enabled = false;
                        btnSaveShortcut.Enabled = true;
                        _mode = Mode.ModShortcut;

                        TreeNode shortcutNode = treeShortcuts.SelectedNode;
                        if (shortcutNode != null)
                        {
                            TreeNodeTypeAndGuid typeAndGuid = (TreeNodeTypeAndGuid)shortcutNode.Tag;

                            MyShortcutsXDataShortcut shortcut = _myShortcuts.First(s => s.Guid == (Guid)typeAndGuid.Guid);
                            txtFriendlyName.Text = shortcut.Name;
                            txtEXEPath.Text = shortcut.Path;
                            txtParameters.Text = shortcut.Parameters;

                            rbExe.Checked = ((ShortcutType)shortcut.Type == ShortcutType.Exe) ? true : false;
                        }

                    }
                    else
                    {
                        EditGroup();
                    }
                }
            }
            else if (e.Modifiers == Keys.Control && e.Shift && e.KeyCode == Keys.C)
            {
                TreeNode node = treeShortcuts.SelectedNode;
                if (node != null)
                {
                    TreeNodeTypeAndGuid typeNode = (TreeNodeTypeAndGuid)node.Tag;
                    if (typeNode.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                    {
                        CopyShortcut();
                    }
                }
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D)
            {
                TreeNode node = treeShortcuts.SelectedNode;
                if (node != null)
                {
                    TreeNodeTypeAndGuid typeNode = (TreeNodeTypeAndGuid)node.Tag;
                    if (typeNode.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                    {
                        DeleteShortCut();
                    }
                    else
                    {
                        DeleteGroup();
                    }
                }
            }
        }

        private void btnBrowseToShortcut_Click(object sender, EventArgs e)
        {
            if (rbExe.Checked)
            {
                openFileDialog1.Filter = "All files (*.*)|*.*";
                openFileDialog1.InitialDirectory = "C:\\Program Files\\";
                openFileDialog1.FilterIndex = 3;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        txtEXEPath.Text = openFileDialog1.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error getting file. Original error: " + ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    DialogResult result = folderBrowserDialog1.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        txtEXEPath.Text = folderBrowserDialog1.SelectedPath;
                        if (!txtEXEPath.Text.EndsWith(Convert.ToString(Path.DirectorySeparatorChar)))
                        {
                            txtEXEPath.Text += Path.DirectorySeparatorChar;
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            EnableDisableShortcutControls(false);
            btnSaveShortcut.Enabled = false;
            cbGroupName.Enabled = false;

            _myShortCutData = ReadWriteShortcuts.ReadShortCutsData();

            if (_myShortCutData == null)
            {
                _myShortCutData = new MyShortcutsXData();
            }

            if (_myShortCutData.Groups.Any())
            {
                foreach (var group in _myShortCutData.Groups)
                {
                    TreeNodeTypeAndGuid groupNode = new TreeNodeTypeAndGuid
                    {
                        Guid = group.Guid,
                        Type = TreeNodeTypeAndGuid.TreeNodeType.Group
                    };
                    TreeNode mainNode = new TreeNode
                    {
                        Text = group.Name,
                        Tag = groupNode
                    };

                    if (_myShortCutData.Shortcuts != null)
                        foreach (var shortcut in _myShortCutData.Shortcuts)
                        {
                            if (shortcut.GroupGuid == group.Guid)
                            {
                                TreeNodeTypeAndGuid shortcutNode = new TreeNodeTypeAndGuid();
                                shortcutNode.Guid = shortcut.Guid;
                                shortcutNode.Type = TreeNodeTypeAndGuid.TreeNodeType.Shortcut;

                                TreeNode subNode = new TreeNode
                                {
                                    Text = $"Name:{shortcut.Name}, Path:{shortcut.Path}, Params:{shortcut.Parameters}",
                                    Tag = shortcutNode
                                };

                                mainNode.Nodes.Add(subNode);

                                _myShortcuts.Add(shortcut);
                            }
                        }

                    _myGroups.Add(group);
                    treeShortcuts.Nodes.Add(mainNode);

                    ComboboxItem cbItem = new ComboboxItem
                    {
                        Text = group.Name,
                        Value = group.Guid
                    };
                    int index = cbGroupName.Items.Add(cbItem);
                    cbGroupName.SelectedIndex = index;
                }

            }

        }

        private void EnableDisableShortcutControls(bool enable)
        {
            txtEXEPath.Enabled = enable;
            txtFriendlyName.Enabled = enable;
            btnSaveShortcut.Enabled = enable;
            btnBrowseToShortcut.Enabled = enable;
            txtParameters.Enabled = enable;
            groupBoxType.Enabled = enable;
            cbGroupName.DropDownStyle = enable == true ? ComboBoxStyle.DropDownList : ComboBoxStyle.Simple;
        }

        private void DisableAllShortcutControls()
        {
            txtEXEPath.Enabled = false;
            txtFriendlyName.Enabled = false;
            btnSaveShortcut.Enabled = false;
            btnBrowseToShortcut.Enabled = false;
            txtParameters.Enabled = false;
            groupBoxType.Enabled = false;
        }

        private void ClearFields()
        {
            txtEXEPath.Text = "";
            txtFriendlyName.Text = "";
            txtParameters.Text = "";
        }

        #region TreeView Functions

        private bool AddNewGroupToTree(MyShortcutsXDataGroup group)
        {
            TreeNodeTypeAndGuid nodeTag = new TreeNodeTypeAndGuid
            {
                Guid = group.Guid,
                Type = TreeNodeTypeAndGuid.TreeNodeType.Group
            };
            var mainNode = new TreeNode
            {
                Text = group.Name,
                Tag = nodeTag
            };

            int index = treeShortcuts.Nodes.Add(mainNode);

            return (index >= 0 ? true : false);


        }

        private bool AddNewShortcutToTree(MyShortcutsXDataShortcut shortcut, int childIndex = -1)
        {
            int index = -1;
            foreach (TreeNode node in treeShortcuts.Nodes)
            {
                TreeNodeTypeAndGuid typeNode = (TreeNodeTypeAndGuid)node.Tag;
                if( (Guid)typeNode.Guid == shortcut.GroupGuid )
                {
                    TreeNodeTypeAndGuid nodeTag = new TreeNodeTypeAndGuid
                    {
                        Guid = shortcut.Guid,
                        Type = TreeNodeTypeAndGuid.TreeNodeType.Shortcut
                    };

                    TreeNode subNode = new TreeNode
                    {
                        Text = $"Name:{shortcut.Name}, Path:{shortcut.Path}, Params:{shortcut.Parameters}",
                        Tag = nodeTag

                    };

                    if (childIndex >= 0)
                    {
                        node.Nodes.Insert(childIndex, subNode);
                        index = childIndex;
                    }
                    else
                    {
                        index = node.Nodes.Add(subNode);
                        if (index < 0)
                            return false;
                    }

                    treeShortcuts.SelectedNode = subNode;
                }
            }
            return (index >= 0 ? true : false);

        }

        private void ModGroupToTree(MyShortcutsXDataGroup group)
        {
            foreach (TreeNode node in treeShortcuts.Nodes)
            {
                TreeNodeTypeAndGuid typeAndGuidNode = (TreeNodeTypeAndGuid)node.Tag;
                
                if ((Guid)typeAndGuidNode.Guid == group.Guid)
                {
                    node.Text = group.Name;
                }
            }
        }

        private void ModShortcutToTree(MyShortcutsXDataShortcut shortcut, Guid originalGroupGuid, bool groupChanged, int childIndex = -1)
        {
            foreach (TreeNode node in treeShortcuts.Nodes)
            {
                TreeNodeTypeAndGuid typeAndGuidGroup = (TreeNodeTypeAndGuid)node.Tag;
                if (groupChanged && (Guid)typeAndGuidGroup.Guid == originalGroupGuid)
                {
                    foreach (TreeNode shortcutNode in node.Nodes)
                    {
                        if (shortcutNode != null)
                        {
                            TreeNodeTypeAndGuid typeAndGuidShortcut = (TreeNodeTypeAndGuid)shortcutNode.Tag;
                            if ((Guid)typeAndGuidShortcut.Guid == shortcut.Guid)
                            {
                                shortcutNode.Remove();
                            }
                        }
                    }
                }
                else if ((Guid)typeAndGuidGroup.Guid == shortcut.GroupGuid)
                {
                    if (groupChanged)
                    {
                        TreeNodeTypeAndGuid nodeTag = new TreeNodeTypeAndGuid
                        {
                            Guid = shortcut.Guid,
                            Type = TreeNodeTypeAndGuid.TreeNodeType.Shortcut
                        };

                        TreeNode subNode = new TreeNode
                        {
                            Text = $"Name:{shortcut.Name}, Path:{shortcut.Path}, Params:{shortcut.Parameters}",
                            Tag = nodeTag
                        };

                        int index = -1;
                        if (childIndex >= 0)
                        {
                            node.Nodes.Insert(childIndex, subNode);
                        }
                        else
                        {
                            index = node.Nodes.Add(subNode);
                        }
                        
                    }
                    else
                    {
                        foreach (TreeNode shortcutNode in node.Nodes)
                        {
                            TreeNodeTypeAndGuid typeAndGuidShortcut = (TreeNodeTypeAndGuid)shortcutNode.Tag;
                            if ((Guid)typeAndGuidShortcut.Guid == shortcut.Guid)
                            {
                                shortcutNode.Text = $"Name:{shortcut.Name}, Path:{shortcut.Path}, Params:{shortcut.Parameters}";
                            }
                        }
                    }

                }
            }
        }
  
        #endregion

        private void ShowWindow()
        {
            base.WindowState = FormWindowState.Normal;
            base.ShowInTaskbar = true;
            base.Show();
            base.Focus();
            notifyIconMain.Visible = false;
            base.CenterToScreen();
        }

        private void FormResize()
        {
            Hide();
            ShowInTaskbar = false;
            notifyIconMain.Visible = true;
            Visible = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == base.WindowState)
            {
                MinimizeMenu();

                contextMenuStripSystemTray.Items.Clear();

                CreateContextMenus();
            }
            else
            {
                base.WindowState = FormWindowState.Normal;
                base.ShowInTaskbar = true;
                base.Show();
                base.Focus();
                notifyIconMain.Visible = false;
                base.CenterToScreen();

            }
        }

        private void MinimizeMenu()
        {
            FormResize();
        }

        private void CreateContextMenus()
        {
            try
            {
                if (_myShortCutData != null && _myShortCutData.Groups.Any())
                {
                    foreach (var group in _myShortCutData.Groups)
                    {
                        ToolStripMenuItem groupMenu = new ToolStripMenuItem();
                        groupMenu.Text = group.Name;
                        TreeNodeTypeAndGuid typeAndGuid = new TreeNodeTypeAndGuid
                        {
                            Guid = group.Guid,
                            Type = TreeNodeTypeAndGuid.TreeNodeType.Group
                        };
                        groupMenu.Tag = typeAndGuid;
                        groupMenu.Click += contextMenuStripSystemTray_Click;

                        if (_myShortCutData.Shortcuts != null)
                        {
                            foreach (var shortcut in _myShortCutData.Shortcuts)
                            {
                                if (shortcut.GroupGuid == group.Guid)
                                {
                                    ToolStripMenuItem shortcutMenu = new ToolStripMenuItem();
                                    shortcutMenu.Text = shortcut.Name;

                                    typeAndGuid = new TreeNodeTypeAndGuid
                                    {
                                        Guid = shortcut.Guid,
                                        Type = TreeNodeTypeAndGuid.TreeNodeType.Shortcut
                                    };
                                    shortcutMenu.Tag = typeAndGuid;

                                    shortcutMenu.Click += contextMenuStripSystemTray_Click; 
                                    groupMenu.DropDownItems.Add(shortcutMenu);
                                }
                            }
                        }
                        contextMenuStripSystemTray.Items.Add(groupMenu);

                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void notifyIconMain_DoubleClick(object sender, EventArgs e)
        {
            ShowWindow();
        }

        //private void MyShortcutsXMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (_bSystemShutdown)
        //    {
        //        e.Cancel = false;
        //    }
        //    else if (!_bCloseAndExit)
        //    {
        //        e.Cancel = true;
        //        MinimizeMenu();

        //        contextMenuStripSystemTray.Items.Clear();

        //        CreateContextMenus();

        //    }
        //}

        private void contextMenuStripSystemTray_Click(object? sender, EventArgs e)
        {
            try
            {
                if (sender == null)
                    return;

                var miClicked = (ToolStripMenuItem)sender;
                {
                    var item = miClicked.Text;
                    var typeAndGuid = (TreeNodeTypeAndGuid)miClicked.Tag;

                    if (typeAndGuid.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                    {
                        var shortcut = _myShortcuts.First(s => s.Guid == (Guid)typeAndGuid.Guid);

                        try
                        {
                            if ((ShortcutType)shortcut.Type == ShortcutType.Folder)
                            {
                                string sFolderDirectory = $"\"{shortcut.Path}\",/e  {shortcut.Parameters}";

                                System.Diagnostics.Process.Start("explorer.exe", sFolderDirectory);
                            }
                            else
                            {
                                //string sExeFile = $"\"{shortcut.Path}\" {shortcut.Parameters}";
                                ProcessStartInfo startInfo = new ProcessStartInfo
                                {
                                    FileName = shortcut.Path,
                                    Arguments = shortcut.Parameters
                                };
                                System.Diagnostics.Process.Start(startInfo);
                            }
                        }
                        catch (Exception Exc)
                        {
                            MessageBox.Show(Exc.ToString());
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

        }

        #region TreeView Drag/Drop

        private void treeShortcuts_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void treeShortcuts_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.  
            Point targetPoint = treeShortcuts.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.  
            treeShortcuts.SelectedNode = treeShortcuts.GetNodeAt(targetPoint);
        }

        private void treeShortcuts_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.  
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        private void treeShortcuts_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = treeShortcuts.PointToClient(new Point(e.X, e.Y));

            TreeNode targetNode = treeShortcuts.GetNodeAt(targetPoint);

            if (e.Data != null)
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

                if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
                {
                    TreeNodeTypeAndGuid typeAndGuidDragged = (TreeNodeTypeAndGuid)draggedNode.Tag;
                    if (typeAndGuidDragged.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                    {
                        int childIndex = -1;
                        TreeNodeTypeAndGuid typeAndGuidTarget = (TreeNodeTypeAndGuid)targetNode.Tag;
                        Guid newGroupGuid = typeAndGuidTarget.Guid;
                        if (typeAndGuidTarget.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                        {
                            MyShortcutsXDataShortcut targetShortcut = _myShortcuts.First(s => s.Guid == (Guid)typeAndGuidTarget.Guid);
                            newGroupGuid = targetShortcut.GroupGuid;
                            childIndex = targetNode.Index;
                        }

                        MyShortcutsXDataShortcut currentShortcut = _myShortcuts.First(s => s.Guid == (Guid)typeAndGuidDragged.Guid);
                        Guid oldGroupGuid = currentShortcut.GroupGuid;
                        MyShortcutsXDataShortcut newShortcut = currentShortcut;
                        newShortcut.GroupGuid = newGroupGuid;

                        treeShortcuts.Nodes.Remove(draggedNode);

                        AddNewShortcutToTree(newShortcut, childIndex);

                        if (_myShortCutData != null)
                        {
                            List<MyShortcutsXDataShortcut> _newShortcuts = new List<MyShortcutsXDataShortcut>();
                             
                            foreach (TreeNode node in treeShortcuts.Nodes)
                            {
                                TreeNodeTypeAndGuid nodeGroupTypeAndGuid = (TreeNodeTypeAndGuid)node.Tag;
                                if (nodeGroupTypeAndGuid.Type == TreeNodeTypeAndGuid.TreeNodeType.Group)
                                {
                                    foreach (TreeNode subnode in node.Nodes)
                                    {
                                        if (subnode != null)
                                        {
                                            TreeNodeTypeAndGuid nodeShortcutTypeAndGuid = (TreeNodeTypeAndGuid)subnode.Tag;

                                            MyShortcutsXDataShortcut shortcut = _myShortcuts.First(s => s.Guid == (Guid)nodeShortcutTypeAndGuid.Guid);
                                            _newShortcuts.Add(shortcut);
                                        }
                                    }
                                }
                            }

                            _myShortcuts.Clear();
                            _myShortcuts = _newShortcuts;
                            _myShortCutData.Shortcuts = _myShortcuts.ToArray();
                            ReadWriteShortcuts.SaveShortCutsData(_myShortCutData);
                        }
                        targetNode.Expand();

                    }

                }
            }
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.  
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node,   
            // call the ContainsNode method recursively using the parent of   
            // the second node.  
            return ContainsNode(node1, node2.Parent);
        }

        #endregion

        #region Add/Edit/Delete/Copy 

        private void AddShortcut()
        {
            ClearFields();
            EnableDisableShortcutControls(true);
            btnSaveShortcut.Enabled = true;
            cbGroupName.Enabled = true;
            _mode = Mode.AddShortcut;

            rbExe.Checked = true;
        }

        private void EditShortcut()
        {
            ClearFields();
            EnableDisableShortcutControls(true);
            cbGroupName.Enabled = true;
            groupBoxType.Enabled = false;
            btnSaveShortcut.Enabled = true;
            _mode = Mode.ModShortcut;

            TreeNode shortcutNode = treeShortcuts.SelectedNode;
            if (shortcutNode != null)
            {
                TreeNodeTypeAndGuid typeAndGuid = (TreeNodeTypeAndGuid)shortcutNode.Tag;
                if (typeAndGuid.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                {
                    MyShortcutsXDataShortcut myShortcut = new MyShortcutsXDataShortcut();
                    foreach (var shortcut in _myShortcuts)
                    {
                        if (shortcut.Guid == (Guid)typeAndGuid.Guid)
                        {
                            txtFriendlyName.Text = shortcut.Name;
                            txtEXEPath.Text = shortcut.Path;
                            txtParameters.Text = shortcut.Parameters;

                            rbExe.Checked = ((ShortcutType)shortcut.Type == ShortcutType.Exe) ? true : false;

                        }
                    }
                }
            }
        }

        private void DeleteShortCut()
        {
            ClearFields();
            DisableAllShortcutControls();
            cbGroupName.Enabled = false;
            _mode = Mode.DelShortcut;
            TreeNode node = treeShortcuts.SelectedNode;
            if (node != null)
            {
                TreeNodeTypeAndGuid typeNode = (TreeNodeTypeAndGuid)node.Tag;
                if (typeNode.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                {
                    MyShortcutsXDataShortcut shortcut = _myShortcuts.First(s => s.Guid == (Guid)typeNode.Guid);
                    MyShortcutsXDataGroup group = _myGroups.First(s => s.Guid == shortcut.GroupGuid);

                    if (DialogResult.Yes == MessageBox.Show(
                            $"This action will delete the shortcut \"{shortcut.Name}\" under \"{group.Name}\" permanently. Continue?",
                            "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        _myShortcuts.Remove(shortcut);
                        if (_myShortCutData != null)
                        {
                            _myShortCutData.Shortcuts = _myShortcuts.ToArray();
                            ReadWriteShortcuts.SaveShortCutsData(_myShortCutData);
                            treeShortcuts.Nodes.Remove(node);
                        }
                    }
                }
            }
        }
        
        private void AddGroup()
        {
            ClearFields();
            EnableDisableShortcutControls(false);
            btnSaveShortcut.Enabled = true;
            cbGroupName.Enabled = true;
            cbGroupName.Text = "New Group";
            _mode = Mode.AddGroup;
        }

        private void EditGroup()
        {
            ClearFields();
            EnableDisableShortcutControls(false);
            btnSaveShortcut.Enabled = true;
            cbGroupName.Enabled = true;

            _mode = Mode.ModGroup;
        }

        private void DeleteGroup()
        {
            TreeNode groupNode = treeShortcuts.SelectedNode;
            if (groupNode != null)
            {
                TreeNodeTypeAndGuid typeAndGuid = (TreeNodeTypeAndGuid)groupNode.Tag;
                if (typeAndGuid.Type == TreeNodeTypeAndGuid.TreeNodeType.Group)
                {
                    MyShortcutsXDataGroup group = _myGroups.First(s => s.Guid == (Guid)typeAndGuid.Guid);
                    if (DialogResult.Yes == MessageBox.Show(
                            $"This action will delete the group \"{group.Name}\" permanently. Any shortcuts under this group will be deleted as well. Continue?",
                            "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if (_myShortCutData != null)
                        {
                            _myShortcuts.RemoveAll(r => r.GroupGuid == group.Guid);
                            _myShortCutData.Shortcuts = _myShortcuts.ToArray();
                            _myGroups.Remove(group);
                            _myShortCutData.Groups = _myGroups.ToArray();
                            ReadWriteShortcuts.SaveShortCutsData(_myShortCutData);
                            treeShortcuts.Nodes.Remove(groupNode);
                        }
                    }
                }
            }
        }
 
        private void CopyShortcut()
        {
            ClearFields();
            EnableDisableShortcutControls(true);
            cbGroupName.Enabled = true;
            groupBoxType.Enabled = false;
            btnSaveShortcut.Enabled = true;
            _mode = Mode.CopyShortcut;

            TreeNode shortcutNode = treeShortcuts.SelectedNode;
            if (shortcutNode != null)
            {
                TreeNodeTypeAndGuid? typeAndGuid = (TreeNodeTypeAndGuid)shortcutNode.Tag;
                if (typeAndGuid.Type == TreeNodeTypeAndGuid.TreeNodeType.Shortcut)
                {
                    MyShortcutsXDataShortcut currentShortcut = _myShortcuts.First(s => s.Guid == (Guid)typeAndGuid.Guid);
                    MyShortcutsXDataShortcut newShortcut = new MyShortcutsXDataShortcut();
                    newShortcut.Name = currentShortcut.Name;
                    newShortcut.GroupGuid = currentShortcut.GroupGuid;
                    newShortcut.Parameters = currentShortcut.Parameters;
                    newShortcut.Path = currentShortcut.Path;
                    newShortcut.Type = currentShortcut.Type;
                    newShortcut.Guid = Guid.NewGuid();

                    _myShortcuts.Add(newShortcut);

                    if (AddNewShortcutToTree(newShortcut))
                    {
                        if (_myShortCutData != null)
                        {
                            _myShortCutData.Shortcuts = _myShortcuts.ToArray();
                            ReadWriteShortcuts.SaveShortCutsData(_myShortCutData);
                        }
                    }

                }
            }
        }

        #endregion

        private void MyShortcutsXMainWindow_KeyDown(object sender, KeyEventArgs e)
        {
 
        }

    }

    public class TreeNodeTypeAndGuid
    {
        public enum TreeNodeType
        {
            Group,
            Shortcut
        }

        public Guid Guid { get; set; }
        public TreeNodeType Type { get; set; }
    }

    public class ComboboxItem
    {
        public string Text { get; set; } = null!;
        public object Value { get; set; } = null!;

        public override string ToString()
        {
            return Text;
        }
    }
}
