using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Довідник_фаната_2.Classes
{
    [Serializable]
    public class Events
    {
        public Sportsmen SportsMen;
        public string Name;
        public DateTime Evetn;
        public string TextEvent;
        public string EventInfo;

        public Events()
        { }
        public Events (string name, string ev, DateTime c )
        {
            Name = name;
            EventInfo = ev;
            Evetn = c;
            GetTextEvent();
        }

        public string[] GetRowStrig()
        {
            string[] s = new string[3];
            s[0] = TextEvent;
            s[1] = Name;
            s[2] = EventInfo;            
            return s;
        }

        public void GetTextEvent()
        {
            DateTime a = this.Evetn;
            this.TextEvent = a.ToString(); 
        }
    }
}
