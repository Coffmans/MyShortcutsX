
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.

using System;

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class MyShortcutsXData
{

    private MyShortcutsXDataGroup[] groupsField;

    private MyShortcutsXDataShortcut[] shortcutsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Group", IsNullable = false)]
    public MyShortcutsXDataGroup[] Groups
    {
        get
        {
            return this.groupsField;
        }
        set
        {
            this.groupsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Shortcut", IsNullable = false)]
    public MyShortcutsXDataShortcut[] Shortcuts
    {
        get
        {
            return this.shortcutsField;
        }
        set
        {
            this.shortcutsField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class MyShortcutsXDataGroup
{

    private Guid guidField;

    private string nameField;

    /// <remarks/>
    public Guid Guid
    {
        get
        {
            return this.guidField;
        }
        set
        {
            this.guidField = value;
        }
    }

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class MyShortcutsXDataShortcut
{

    private Guid groupGuidField;

    private Guid guidField;

    private object typeField;

    private string pathField;

    private string nameField;

    private string parametersField;

    /// <remarks/>
    public Guid GroupGuid
    {
        get
        {
            return this.groupGuidField;
        }
        set
        {
            this.groupGuidField = value;
        }
    }

    /// <remarks/>
    public Guid Guid
    {
        get
        {
            return this.guidField;
        }
        set
        {
            this.guidField = value;
        }
    }

    /// <remarks/>
    public object Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    public string Path
    {
        get
        {
            return this.pathField;
        }
        set
        {
            this.pathField = value;
        }
    }

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public string Parameters
    {
        get
        {
            return this.parametersField;
        }
        set
        {
            this.parametersField = value;
        }
    }
}

