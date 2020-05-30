using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Довідник_фаната_2.Classes
{
    [Serializable]
    public class EventsList
    {
        //поля
        public List<Events> list { get; set; }

        public EventsList()
        { }

        //методи
        //Додавання
        public void Add(Events ev)
        {
            if (list == null)
            {
                list = new List<Events>();
            }            
            this.list.Add(ev);
        }

        //видалення
        public void Delete(ListView lv)
        {
            if (list != null)
            {
                if (MessageBox.Show("Ви впевнені, що хочете видалити спорсмена", "Видалити", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int a = lv.SelectedIndices[0];
                    lv.Items.RemoveAt(lv.SelectedIndices[0]);
                    list.RemoveAt(a);
                }
            }
            else MessageBox.Show("Колекція пуста");
        }

        //Збереження у файл
        public string SaveToFile(Events a)
        {
            string res =
            $"\n Коли: { a.TextEvent}" +
            $"\n Що: { a.EventInfo}" +
            $"\n Спортсмен: { a.Name}";
            return res;
        }

        //Пошук
        public EventsList Filter(string s, EventsList ex)
        {
            EventsList res = new EventsList();
            EventsList res2 = new EventsList();
            int Len = ex.list.Count();
            for (int i = 0; i < Len; i++)
            {
                Events temp = ex.list[i];
                res.Add(temp);
            }
            if (s != "")
            {
                foreach (Events a in res.list)
                {
                    if (a.Name.IndexOf(s) != -1)
                        res2.Add(a);
                    if (a.EventInfo.IndexOf(s) != -1)
                        res2.Add(a);
                }
                return res2;
            }
            return res;
        }

        //збереження-збереження
        public void Save()
        {
            XmlSerializer xml = new XmlSerializer(typeof(EventsList));
            if (File.Exists("Calendar.xml"))
            {
                File.Delete("Calendar.xml");
            }
            using (FileStream fs = new FileStream("Calendar.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, this);
            }
        }
        //збереження-відкриття
        public EventsList Open()
        {
            XmlSerializer xml = new XmlSerializer(typeof(EventsList));
            using (FileStream fs = new FileStream("Calendar.xml", FileMode.OpenOrCreate))
            {                
               return (EventsList)xml.Deserialize(fs);
            }
        }
    }
}
