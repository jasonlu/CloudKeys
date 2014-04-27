
using System;
using System.Xml.Serialization;
namespace CloudKeysModel
{
    [Serializable]
    public class Key
    {
        /*
        private Group _group;

        [XmlIgnore]
        public Group Group
        {
            get { return _group; }
            set { _group = value; }
        }
         */

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _url;

        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _notes;

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public Key Clone()
        {
            Key k = new Key();
            k.Title = _title;
            k.URL = _url;
            k.Username = _username;
            k.Password = _password;
            k.Notes = _notes;
            // k.Group = _group;
            return k;
        }

    }
}
