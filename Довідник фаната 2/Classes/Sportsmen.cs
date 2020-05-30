using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Довідник_фаната_2
{
    [Serializable]
    public class Sportsmen
    {
        //поля
        public string SecName;
        public string Name;
        public string ThirdName;
        public string Country;
        public string Gromad;
        public string Age;
        public DateTime Datetime;
        public string Sex;
        public double Hight;
        public double Weight;
        public string Sport;
        public string Team;
        public string AddiInfo;


        //Конструтори
        //конструктор без парметрів
        public Sportsmen()
        { }

        //конструктор
        public Sportsmen(string scname, string name, string thname, string coun, string gromad, DateTime age, string sex, string sport, string team = "", string addin = "", double h = 0, double w = 0)
        {
            SecName = scname;
            Name = name;
            ThirdName = thname;
            Country = coun;
            Gromad = gromad;
            Datetime = age;
            Age = age.ToString();
            Sex = sex;
            Hight = GetValue(" зріс ", h);
            Weight = GetValue(" вага ", w);
            Sport = sport;
            Team = team;
            AddiInfo = addin;
        }

        //методи
        private double GetValue (string param, double smth)
        {
            if (smth < 10)
            {
                MessageBox.Show($"Занадто малий параметр {param}");
                throw new Exception();
            }
            return smth;
        }

        public string [] GetRowStrig()
        {
            string[] s = new string[12];
            s[0] = SecName;
            s[1] = Name;
            s[2] = ThirdName;
            s[3] = Country;
            s[4] = Gromad;
            s[5] = Age;
            s[6] = Sex;
            if (Hight==0)
            {
                s[7] = "";
            }
            else
            {
                s[7] = Convert.ToString(Hight);
            }
            if (Weight == 0)
            {
                s[8] = "";
            }
            else
            {
                s[8] = Convert.ToString(Weight);
            }            
            s[9] = Sport;
            s[10] = Team;
            s[11] = AddiInfo;
            return s;
        }
        
        //сделать проверку, чтобы числовые переменные были числовыми, а строковые - строковыми
        //Властивості
        public string nameProp
        {
            get {return this.Name;}
            set { Name = value; }
        }
        public string secnameProp
        {
            get { return this.SecName; }
            set { SecName = value; }
        }
        public string thirnameProp
        {
            get { return this.ThirdName; }
            set { ThirdName = value; }
        }
        public string countProp
        {
            get { return this.Country; }
            set { Country = value; }
        }
        public string gromadProp
        {
            get { return this.Gromad; }
            set { Gromad = value; }
        }        
        public string sexProp
        {
            get { return this.Sex; }
            set { Sex = value; }
        }
        public double heightProp
        {
            get { return this.Hight; }
            set
            {
                if (value<10)
                {
                    throw new Exception("Занадто малий зріст");
                }
                else
                {
                    Hight = value;
                }
            }
        }
        public double weightProp
        {
            get { return this.Weight; }
            set { Weight = value; }
        }
        public string sportProp
        {
            get { return this.Sport; }
            set { Sport = value; }
        }
        public string teamProp
        {
            get { return this.Team; }
            set { Team = value; }
        }
        public string addInfProp
        {
            get { return this.AddiInfo; }
            set { AddiInfo = value; }
        }
    }
}
