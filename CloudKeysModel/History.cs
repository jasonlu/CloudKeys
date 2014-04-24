using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;

namespace CloudKeysModel
{
    public enum Action
    {
        Create, Read, Update, Delete
    };

    [Serializable]
    public class History
    {
        public string Description { get; set; }

        public string Filename { get; set; }

        [XmlIgnore]
        public object From { get; set; }
        public DateTime At { get; set; }



        public Action Action { get; set; }


        [XmlIgnore]
        public History Previous { get; set; }

        [XmlIgnore]
        public History Next { get; set; }

        public History(object obj)
        {
            Next = null;
            At = DateTime.Now;
            Description = "";
            From = (obj);
        }

        public void Commit()
        {
            string sLog;
            string sEvent;

            string sSource = "CloudKey By Jason Lu";
            sLog = "Application";
            sEvent = Description;
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            //EventLog.WriteEntry(sSource, sEvent, EventLogEntryType.Warning, (int)Action);
            EventLog.WriteEntry(sSource, sEvent, EventLogEntryType.Information, (int)Action);
        }


    }
}
