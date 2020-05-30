using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Довідник_фаната_2
{
    [Serializable]
    public class SportmwnsList
    {
        //поля
        public List<Sportsmen> list;

        //Конструтор
        public SportmwnsList()
        { }

        //методи

        //Список спортсменів (імена)
        public void GetNames(ComboBox cb)
        {
            if (list != null)
            {
                int len = list.Count;
                string[] res = new string[len];
                for (int i = 0; i < len; i++)
                {
                    res[i] += list[i].SecName + " "+ list[i].Name + " " + list[i].ThirdName;
                    cb.Items.Add(res[i]);
                }                
            }
        }
        //додавання нового
        public void Add(Sportsmen s)
        {
            if (list == null)
            {
                list = new List<Sportsmen>();
            }
            list.Add(s);
        }

        //збереження-збереження
        public void Save()
        {
            XmlSerializer xml = new XmlSerializer(typeof(SportmwnsList));
            if (File.Exists("DovidnikFanataIfo.xml"))
            {
                File.Delete("DovidnikFanataIfo.xml");
            }
            using (FileStream fs = new FileStream("DovidnikFanataIfo.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, this);
            }
        }

        //збереження-відкриття
        public SportmwnsList Open()
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(SportmwnsList));
                using (FileStream fs = new FileStream("DovidnikFanataIfo.xml", FileMode.OpenOrCreate))
                {
                    return (SportmwnsList)xml.Deserialize(fs);
                }
            }
            catch
            {
                MessageBox.Show("Файл пустий");
            }
            return new SportmwnsList();
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

        public string SaveToFile(Sportsmen a)
        {
            string res = $"{a.SecName}" +
            $"\n {a.Name}" +
            $"\n{ a.ThirdName}" +
            $"\n Дата народження: { a.Age}" +
            $"\n Зріст: { a.Hight}" +
            $"\n Вага: { a.Weight}" +
            $"\n Країна походення: { a.Country}" +
            $"\n Громадянство: { a.Gromad}" +
            $"\n Команда: { a.Team}" +
            $"\n Вид спорту: { a.Sport}" +
            $"\n Особисті нагороди: { a.AddiInfo}";
            return res;
        }

        //Пошук
        public SportmwnsList Find (SportmwnsList ex, string one = "", string two="", string three="", string four="")
        {
            SportmwnsList res = new SportmwnsList();
            int Len = ex.list.Count();
            for (int i = 0; i <Len; i++)
            {
                Sportsmen temp = ex.list[i];
                res.Add(temp);
            }
            if (one!="")
            {
                res.list = res.FiltrSurn(one, res);
            }
            if (two != "")
            {
                res.list = res.FiltrName(two, res);
            }
            if (three != "")
            {
                res.list = res.FiltrCount(three, res);
            }
            if (four != "")
            {
                res.list = res.FiltrSport(four, res);
            }
            return res;             
        }

        //Пошук  фамілія
        public List<Sportsmen> FiltrSurn(string s, SportmwnsList slst)
        {
            List<Sportsmen> res = new List<Sportsmen>();
            int Len = slst.list.Count;
            if (s != "")
            {
                foreach (Sportsmen a in slst.list)
                {
                    if (a.SecName==s)
                        res.Add(a);
                }
            }
            return res;
        }

        //Пошук  iм'я
        public List<Sportsmen> FiltrName(string s, SportmwnsList slst)
        {
            List<Sportsmen> res = new List<Sportsmen>();
            int Len = slst.list.Count;
            if (s != "")
            {
                foreach (Sportsmen a in slst.list)
                {
                    if (a.Name == s)
                        res.Add(a);
                }
            }
            return res;
        }

        //Пошук країна
        public List<Sportsmen> FiltrCount(string s, SportmwnsList slst)
        {
            List<Sportsmen> res = new List<Sportsmen>();
            int Len = slst.list.Count;
            if (s != "")
            {
                foreach (Sportsmen a in slst.list)
                {
                    if (a.Country == s || a.Gromad == s)
                        res.Add(a);
                }
            }
            return res;
        }

        //Пошук спорт
        public List<Sportsmen> FiltrSport(string s, SportmwnsList slst)
        {
            List<Sportsmen> res = new List<Sportsmen>();
            int Len = slst.list.Count;
            if (s != "")
            {
                foreach (Sportsmen a in slst.list)
                {
                    if (a.Sport == s)
                        res.Add(a);
                }
            }
            return res;
        }


        //Редагування
        public int Update(ListView lv)
        {
            if (list != null)
            {
                try
                {
                    if (MessageBox.Show("Ви впевнені, що хочете змінити спорсмена", "Видалити", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        int a = lv.SelectedIndices[0];
                        return a;
                    }
                }
                catch
                {
                    MessageBox.Show("Не можна оновлювати, не обравши спортсмена");
                }
            }
            else MessageBox.Show("Колекція пуста");
            return -1;
        }
    }
}
