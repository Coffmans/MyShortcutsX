using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyShortcutsX
{
    public class ReadWriteShortcuts
    {

        public static MyShortcutsXData? ReadShortCutsData()
        {
            var shortcutsData = new MyShortcutsXData();
            if (File.Exists(Constants.StationConfigFile))
            {
                var reader = new System.Xml.Serialization.XmlSerializer(typeof(MyShortcutsXData));

                using var file = new System.IO.StreamReader(Constants.StationConfigFile);
                shortcutsData = reader.Deserialize(file) as MyShortcutsXData;
                file.Close();
            }

            return shortcutsData;
        }

        public static void SaveShortCutsData(MyShortcutsXData savedShortCutsData)
        {
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(MyShortcutsXData));

            var file = new System.IO.StreamWriter(Constants.StationConfigFile);
            writer.Serialize(file, savedShortCutsData);
            file.Close();

        }
    }
}
