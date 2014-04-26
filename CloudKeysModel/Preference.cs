using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CloudKeysModel
{
    [Serializable]
    public class Preference
    {

        private bool _saveToCloud = true;
        [DisplayName("Save files to Cloud(DropBox)")]
        public bool SaveToCloud
        {
            get { return _saveToCloud; }
            set { _saveToCloud = value; }
        }


        private string _token = "";
        [Browsable(false)]
        public string DropBoxToken
        {
            get { return _token; }
            set { _token = value; }
        }

        private string _secret = "";
        [Browsable(false)]
        public string DropBoxSecret
        {
            get { return _secret; }
            set { _secret = value; }
        }


        private List<string> _recentFiles = new List<string>();

        [Browsable(false)]
        public List<string> RecentFiles
        {
            get { return _recentFiles; }
            set { _recentFiles = value; }
        }

        private int _recentFileLimit = 10;
        [Browsable(false)]
        public int RecentFileLimit
        {
            get { return _recentFileLimit; }
            set { _recentFileLimit = value; }
        }

        private Font _font;

        [XmlIgnore]
        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }


        [XmlElement("Font"), Browsable(false)]
        public string SerializeFontAttribute
        {
            get
            {
                return FontXmlConverter.ConvertToString(Font);
            }
            set
            {
                Font = FontXmlConverter.ConvertToFont(value);
            }
        }


        private string _fontName = "Arial";

         [CategoryAttribute("Document Settings"),
        DefaultValueAttribute("Arial"), Browsable(false)]
        public string FontName
        {
            get { return _fontName; }
            set { _fontName = value; }
        }

         private float _fontSize;

        [Browsable(false)]
         public float FontSize
         {
             get { return _fontSize; }
             set { _fontSize = value; }
         }

        private bool _trayIcon = false;
         
        [CategoryAttribute("Document Settings"),
        DefaultValueAttribute(false), DisplayName("Minimize to tray")]
        public bool TrayIcon
        {
            get { return _trayIcon; }
            set { _trayIcon = value; }
        }
    }
}


public static class FontXmlConverter
{
    public static string ConvertToString(Font font)
    {
        try
        {
            if (font != null)
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                return converter.ConvertToString(font);
            }
            else
                return null;
        }
        catch { System.Diagnostics.Debug.WriteLine("Unable to convert"); }
        return null;
    }
    public static Font ConvertToFont(string fontString)
    {
        try
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(fontString);
        }
        catch { System.Diagnostics.Debug.WriteLine("Unable to convert"); }
        return null;
    }
}