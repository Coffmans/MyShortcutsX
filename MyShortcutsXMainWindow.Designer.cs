namespace MyShortcutsX
{
    partial class MyShortcutsXMainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyShortcutsXMainWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.rbExe = new System.Windows.Forms.RadioButton();
            this.rbFolder = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveShortcut = new System.Windows.Forms.Button();
            this.txtParameters = new System.Windows.Forms.TextBox();
            this.lblFriendlyName = new System.Windows.Forms.Label();
            this.lblExePath = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtFriendlyName = new System.Windows.Forms.TextBox();
            this.btnBrowseToShortcut = new System.Windows.Forms.Button();
            this.txtEXEPath = new System.Windows.Forms.TextBox();
            this.cbGroupName = new System.Windows.Forms.ComboBox();
            this.treeShortcuts = new System.Windows.Forms.TreeView();
            this.contextMenuStripTreeList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNewGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonNewShortcut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditShortcut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteShortcut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCloneShortcut = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStripSystemTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBoxType.SuspendLayout();
            this.contextMenuStripTreeList.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSaveShortcut);
            this.groupBox1.Controls.Add(this.txtParameters);
            this.groupBox1.Controls.Add(this.lblFriendlyName);
            this.groupBox1.Controls.Add(this.lblExePath);
            this.groupBox1.Controls.Add(this.lblGroupName);
            this.groupBox1.Controls.Add(this.txtFriendlyName);
            this.groupBox1.Controls.Add(this.btnBrowseToShortcut);
            this.groupBox1.Controls.Add(this.txtEXEPath);
            this.groupBox1.Controls.Add(this.cbGroupName);
            this.groupBox1.Location = new System.Drawing.Point(790, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 292);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shortcut Properties";
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.rbExe);
            this.groupBoxType.Controls.Add(this.rbFolder);
            this.groupBoxType.Location = new System.Drawing.Point(8, 88);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(125, 47);
            this.groupBoxType.TabIndex = 14;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Type";
            // 
            // rbExe
            // 
            this.rbExe.AutoSize = true;
            this.rbExe.Location = new System.Drawing.Point(7, 17);
            this.rbExe.Name = "rbExe";
            this.rbExe.Size = new System.Drawing.Size(43, 19);
            this.rbExe.TabIndex = 12;
            this.rbExe.TabStop = true;
            this.rbExe.Text = "File";
            this.rbExe.UseVisualStyleBackColor = true;
            // 
            // rbFolder
            // 
            this.rbFolder.AutoSize = true;
            this.rbFolder.Location = new System.Drawing.Point(57, 17);
            this.rbFolder.Name = "rbFolder";
            this.rbFolder.Size = new System.Drawing.Size(58, 19);
            this.rbFolder.TabIndex = 13;
            this.rbFolder.TabStop = true;
            this.rbFolder.Text = "Folder";
            this.rbFolder.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Parameters";
            // 
            // btnSaveShortcut
            // 
            this.btnSaveShortcut.Location = new System.Drawing.Point(194, 250);
            this.btnSaveShortcut.Name = "btnSaveShortcut";
            this.btnSaveShortcut.Size = new System.Drawing.Size(75, 23);
            this.btnSaveShortcut.TabIndex = 11;
            this.btnSaveShortcut.Text = "Save";
            this.btnSaveShortcut.UseVisualStyleBackColor = true;
            this.btnSaveShortcut.Click += new System.EventHandler(this.btnSaveShortcut_Click);
            // 
            // txtParameters
            // 
            this.txtParameters.Location = new System.Drawing.Point(8, 215);
            this.txtParameters.Name = "txtParameters";
            this.txtParameters.Size = new System.Drawing.Size(424, 23);
            this.txtParameters.TabIndex = 10;
            // 
            // lblFriendlyName
            // 
            this.lblFriendlyName.AutoSize = true;
            this.lblFriendlyName.Location = new System.Drawing.Point(178, 88);
            this.lblFriendlyName.Name = "lblFriendlyName";
            this.lblFriendlyName.Size = new System.Drawing.Size(84, 15);
            this.lblFriendlyName.TabIndex = 4;
            this.lblFriendlyName.Text = "Friendly Name";
            // 
            // lblExePath
            // 
            this.lblExePath.AutoSize = true;
            this.lblExePath.Location = new System.Drawing.Point(8, 147);
            this.lblExePath.Name = "lblExePath";
            this.lblExePath.Size = new System.Drawing.Size(93, 15);
            this.lblExePath.TabIndex = 6;
            this.lblExePath.Text = "Path to Shortcut";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(8, 27);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(75, 15);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "Group Name";
            // 
            // txtFriendlyName
            // 
            this.txtFriendlyName.Location = new System.Drawing.Point(178, 106);
            this.txtFriendlyName.Name = "txtFriendlyName";
            this.txtFriendlyName.Size = new System.Drawing.Size(254, 23);
            this.txtFriendlyName.TabIndex = 5;
            // 
            // btnBrowseToShortcut
            // 
            this.btnBrowseToShortcut.Location = new System.Drawing.Point(406, 164);
            this.btnBrowseToShortcut.Name = "btnBrowseToShortcut";
            this.btnBrowseToShortcut.Size = new System.Drawing.Size(26, 23);
            this.btnBrowseToShortcut.TabIndex = 8;
            this.btnBrowseToShortcut.Text = "...";
            this.btnBrowseToShortcut.UseVisualStyleBackColor = true;
            this.btnBrowseToShortcut.Click += new System.EventHandler(this.btnBrowseToShortcut_Click);
            // 
            // txtEXEPath
            // 
            this.txtEXEPath.Location = new System.Drawing.Point(8, 165);
            this.txtEXEPath.Name = "txtEXEPath";
            this.txtEXEPath.Size = new System.Drawing.Size(392, 23);
            this.txtEXEPath.TabIndex = 7;
            // 
            // cbGroupName
            // 
            this.cbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbGroupName.FormattingEnabled = true;
            this.cbGroupName.Location = new System.Drawing.Point(6, 49);
            this.cbGroupName.Name = "cbGroupName";
            this.cbGroupName.Size = new System.Drawing.Size(426, 23);
            this.cbGroupName.TabIndex = 1;
            // 
            // treeShortcuts
            // 
            this.treeShortcuts.AllowDrop = true;
            this.treeShortcuts.ContextMenuStrip = this.contextMenuStripTreeList;
            this.treeShortcuts.HideSelection = false;
            this.treeShortcuts.Location = new System.Drawing.Point(6, 59);
            this.treeShortcuts.Name = "treeShortcuts";
            this.treeShortcuts.Size = new System.Drawing.Size(750, 669);
            this.treeShortcuts.TabIndex = 6;
            this.treeShortcuts.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeShortcuts_ItemDrag);
            this.treeShortcuts.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeShortcuts_AfterSelect);
            this.treeShortcuts.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeShortcuts_DragDrop);
            this.treeShortcuts.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeShortcuts_DragEnter);
            this.treeShortcuts.DragOver += new System.Windows.Forms.DragEventHandler(this.treeShortcuts_DragOver);
            this.treeShortcuts.DoubleClick += new System.EventHandler(this.treeShortcuts_DoubleClick);
            // 
            // contextMenuStripTreeList
            // 
            this.contextMenuStripTreeList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGroupToolStripMenuItem,
            this.editGroupToolStripMenuItem,
            this.deleteGroupToolStripMenuItem,
            this.toolStripSeparator1,
            this.addShortcutToolStripMenuItem,
            this.editShortcutToolStripMenuItem,
            this.copyShortcutToolStripMenuItem,
            this.deleteShortcutToolStripMenuItem});
            this.contextMenuStripTreeList.Name = "contextMenuStripTreeList";
            this.contextMenuStripTreeList.Size = new System.Drawing.Size(227, 164);
            // 
            // addGroupToolStripMenuItem
            // 
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.addGroupToolStripMenuItem.Text = "Add Group";
            this.addGroupToolStripMenuItem.Click += new System.EventHandler(this.addGroupToolStripMenuItem_Click);
            // 
            // editGroupToolStripMenuItem
            // 
            this.editGroupToolStripMenuItem.Name = "editGroupToolStripMenuItem";
            this.editGroupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.editGroupToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.editGroupToolStripMenuItem.Text = "Edit Group";
            this.editGroupToolStripMenuItem.Click += new System.EventHandler(this.editGroupToolStripMenuItem_Click);
            // 
            // deleteGroupToolStripMenuItem
            // 
            this.deleteGroupToolStripMenuItem.Name = "deleteGroupToolStripMenuItem";
            this.deleteGroupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.deleteGroupToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.deleteGroupToolStripMenuItem.Text = "Delete Group";
            this.deleteGroupToolStripMenuItem.Click += new System.EventHandler(this.deleteGroupToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // addShortcutToolStripMenuItem
            // 
            this.addShortcutToolStripMenuItem.Name = "addShortcutToolStripMenuItem";
            this.addShortcutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.addShortcutToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.addShortcutToolStripMenuItem.Text = "Add Shortcut";
            this.addShortcutToolStripMenuItem.Click += new System.EventHandler(this.addShortcutToolStripMenuItem_Click);
            // 
            // editShortcutToolStripMenuItem
            // 
            this.editShortcutToolStripMenuItem.Name = "editShortcutToolStripMenuItem";
            this.editShortcutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editShortcutToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.editShortcutToolStripMenuItem.Text = "Edit Shortcut";
            this.editShortcutToolStripMenuItem.Click += new System.EventHandler(this.editShortcutToolStripMenuItem_Click);
            // 
            // copyShortcutToolStripMenuItem
            // 
            this.copyShortcutToolStripMenuItem.Name = "copyShortcutToolStripMenuItem";
            this.copyShortcutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.copyShortcutToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.copyShortcutToolStripMenuItem.Text = "Copy Shortcut";
            this.copyShortcutToolStripMenuItem.Click += new System.EventHandler(this.copyShortcutToolStripMenuItem_Click);
            // 
            // deleteShortcutToolStripMenuItem
            // 
            this.deleteShortcutToolStripMenuItem.Name = "deleteShortcutToolStripMenuItem";
            this.deleteShortcutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.deleteShortcutToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.deleteShortcutToolStripMenuItem.Text = "Delete Shortcut";
            this.deleteShortcutToolStripMenuItem.Click += new System.EventHandler(this.deleteShortcutToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Controls.Add(this.treeShortcuts);
            this.groupBox2.Location = new System.Drawing.Point(28, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(762, 745);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shortcuts";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNewGroup,
            this.toolStripButtonEditGroup,
            this.toolStripButtonDeleteGroup,
            this.toolStripSeparator2,
            this.toolStripButtonNewShortcut,
            this.toolStripButtonEditShortcut,
            this.toolStripButtonDeleteShortcut,
            this.toolStripButtonCloneShortcut});
            this.toolStrip1.Location = new System.Drawing.Point(3, 19);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(756, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNewGroup
            // 
            this.toolStripButtonNewGroup.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNewGroup.Image")));
            this.toolStripButtonNewGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewGroup.Name = "toolStripButtonNewGroup";
            this.toolStripButtonNewGroup.Size = new System.Drawing.Size(87, 22);
            this.toolStripButtonNewGroup.Text = "New Group";
            this.toolStripButtonNewGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // toolStripButtonEditGroup
            // 
            this.toolStripButtonEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditGroup.Image")));
            this.toolStripButtonEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditGroup.Name = "toolStripButtonEditGroup";
            this.toolStripButtonEditGroup.Size = new System.Drawing.Size(83, 22);
            this.toolStripButtonEditGroup.Text = "Edit Group";
            this.toolStripButtonEditGroup.Click += new System.EventHandler(this.btnModGroup_Click);
            // 
            // toolStripButtonDeleteGroup
            // 
            this.toolStripButtonDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteGroup.Image")));
            this.toolStripButtonDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteGroup.Name = "toolStripButtonDeleteGroup";
            this.toolStripButtonDeleteGroup.Size = new System.Drawing.Size(96, 22);
            this.toolStripButtonDeleteGroup.Text = "Delete Group";
            this.toolStripButtonDeleteGroup.Click += new System.EventHandler(this.btnDelGroup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonNewShortcut
            // 
            this.toolStripButtonNewShortcut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNewShortcut.Image")));
            this.toolStripButtonNewShortcut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewShortcut.Name = "toolStripButtonNewShortcut";
            this.toolStripButtonNewShortcut.Size = new System.Drawing.Size(99, 22);
            this.toolStripButtonNewShortcut.Text = "New Shortcut";
            this.toolStripButtonNewShortcut.Click += new System.EventHandler(this.AddShortcut_Click);
            // 
            // toolStripButtonEditShortcut
            // 
            this.toolStripButtonEditShortcut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditShortcut.Image")));
            this.toolStripButtonEditShortcut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditShortcut.Name = "toolStripButtonEditShortcut";
            this.toolStripButtonEditShortcut.Size = new System.Drawing.Size(95, 22);
            this.toolStripButtonEditShortcut.Text = "Edit Shortcut";
            this.toolStripButtonEditShortcut.Click += new System.EventHandler(this.btnModShortcut_Click);
            // 
            // toolStripButtonDeleteShortcut
            // 
            this.toolStripButtonDeleteShortcut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteShortcut.Image")));
            this.toolStripButtonDeleteShortcut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteShortcut.Name = "toolStripButtonDeleteShortcut";
            this.toolStripButtonDeleteShortcut.Size = new System.Drawing.Size(108, 22);
            this.toolStripButtonDeleteShortcut.Text = "Delete Shortcut";
            this.toolStripButtonDeleteShortcut.Click += new System.EventHandler(this.btnDelShortcut_Click);
            // 
            // toolStripButtonCloneShortcut
            // 
            this.toolStripButtonCloneShortcut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCloneShortcut.Image")));
            this.toolStripButtonCloneShortcut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCloneShortcut.Name = "toolStripButtonCloneShortcut";
            this.toolStripButtonCloneShortcut.Size = new System.Drawing.Size(106, 22);
            this.toolStripButtonCloneShortcut.Text = "Clone Shortcut";
            this.toolStripButtonCloneShortcut.Click += new System.EventHandler(this.copyShortcutToolStripMenuItem_Click);
            // 
            // contextMenuStripSystemTray
            // 
            this.contextMenuStripSystemTray.Name = "contextMenuStripSystemTray";
            this.contextMenuStripSystemTray.Size = new System.Drawing.Size(61, 4);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripSystemTray;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "MyShortcutsX";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.DoubleClick += new System.EventHandler(this.notifyIconMain_DoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MyShortcutsXMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 826);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyShortcutsXMainWindow";
            this.Text = "MyShortcutsX";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyShortcutsXMainWindow_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            this.contextMenuStripTreeList.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveShortcut;
        private System.Windows.Forms.Label lblFriendlyName;
        private System.Windows.Forms.Label lblExePath;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtFriendlyName;
        private System.Windows.Forms.Button btnBrowseToShortcut;
        private System.Windows.Forms.TextBox txtEXEPath;
        private System.Windows.Forms.ComboBox cbGroupName;
        private System.Windows.Forms.TreeView treeShortcuts;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParameters;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTreeList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSystemTray;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.RadioButton rbExe;
        private System.Windows.Forms.RadioButton rbFolder;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addShortcutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editShortcutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteShortcutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyShortcutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewGroup;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditGroup;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewShortcut;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditShortcut;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteShortcut;
        private System.Windows.Forms.ToolStripButton toolStripButtonCloneShortcut;
    }
}
