using System.Collections.Generic;
using System.Drawing;

namespace CloudKeysModel
{
    public class Group
    {
        private Color _color;

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private List<Key> _keys;

        public List<Key> Keys
        {
            get { return _keys; }
            set { _keys = value; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Group()
        {
            _keys = new List<Key>();
        }

        public Group Clone()
        {
            Group g = new Group();
            g.Keys = new List<Key>();
            foreach (Key k in _keys)
            {
                Key newKey = k.Clone();
                // newKey.Group = g;
                g.Keys.Add(newKey);
            }
            g.Title = _title;
            g._color = _color;
            return g;
        }
    }
}
