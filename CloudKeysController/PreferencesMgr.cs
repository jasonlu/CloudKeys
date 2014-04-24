using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CloudKeysModel;
using System.Xml.Serialization;

namespace CloudKeysController
{
    public class PreferencesMgr
    {
        static Preference pre = new Preference();
        static public Preference Preference {
            get { return pre; }
            set { pre = value; }
        }
        static public bool LoadFile()
        {
            string exe = Assembly.GetExecutingAssembly().Location;
            string filename = Path.GetDirectoryName(exe) + "\\setting.xml";
            if (!File.Exists(filename))
            {
                SaveFile();
            }
            XmlSerializer serializer = new XmlSerializer(typeof(Preference));
            using (StreamReader reader = new StreamReader(filename))
            {
                pre = (Preference)serializer.Deserialize(reader);
            }

            return true;
        }

        static public bool SaveFile()
        {
            string exe = Assembly.GetExecutingAssembly().Location;
            string filename = Path.GetDirectoryName(exe) + "\\setting.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Preference));
            using (StreamWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, pre);
            }

            return true;
        }
    }
}
