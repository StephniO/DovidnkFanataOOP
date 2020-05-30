using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Довідник_фаната_2.Forms
{
    public partial class Calendar : Form
    {
       
        public SportmwnsList slist = new SportmwnsList();
        public Classes.EventsList Elist;
        public Classes.EventsList Elist2;
        public Calendar()
        {
            InitializeComponent();
            //EventsListView
        }

        public Calendar(SportmwnsList s)
        {
            InitializeComponent();
            slist = s;
            EventsListView.View = View.Details;
            EventsListView.FullRowSelect = true;
            Cleare();
            if (Elist != null)
            {
                update(Elist);
            }
            ComboboxValues();
            if (Elist == null)
            {
                Elist = new Classes.EventsList();
            }
            Elist = Elist.Open();
            update(Elist);
        }

        public void ComboboxValues()
        {
            slist.GetNames(comboBox1);                        
        }

        //метод витирання усіх текстових полів
        private static void CleanAllTextBoxesIn(Control parent)
        {
            foreach (Control item in parent.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                    item.Text = string.Empty;

                if (item.GetType() == typeof(GroupBox))
                    CleanAllTextBoxesIn(item);
                if (item.GetType()== typeof(ComboBox))
                    item.Text = string.Empty;
                if (item.GetType() == typeof(DateTimePicker))
                    item.Text = string.Empty;
            }
        }
        //Листвью
        //Заповнення Листвью
        private void update(Classes.EventsList listi)
        {
            Cleare();
            //ROW
            String[] row;
            if (listi.list != null)
            {
                foreach (Classes.Events ev in listi.list)
                {
                    row = ev.GetRowStrig();
                    ListViewItem item = new ListViewItem(row);
                    EventsListView.Items.Add(item);
                }
            }
            Elist2 = Elist;
        }

        private void update2(Classes.EventsList listi)
        {
            Cleare();
            //ROW
            String[] row;
            if (listi.list != null)
            {
                foreach (Classes.Events ev in listi.list)
                {
                    row = ev.GetRowStrig();
                    ListViewItem item = new ListViewItem(row);
                    EventsListView.Items.Add(item);
                }
            }
        }

        //видалення листьвю
        private void Cleare()
        {
            EventsListView.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*string sportsmen = comboBox1.Text;
            string ev = txtEv.Text;
            DateTime date = dateTimePicker1.Value;
            Classes.Events a = new Classes.Events(sportsmen, ev, date);
            if(Elist==null)
            {
                Elist = new Classes.EventsList();
            }
            Elist.Add(a);
            CleanAllTextBoxesIn(this);
            update(Elist);*/
            try
            {
                 if (comboBox1.Text != "" && dateTimePicker1.Value != null && txtEv.Text != "")
                 {
                     string sportsmen = comboBox1.Text;
                     string ev = txtEv.Text;
                     DateTime date = dateTimePicker1.Value;
                     Classes.Events a = new Classes.Events(sportsmen, ev, date);
                     Elist.Add(a);
                     CleanAllTextBoxesIn(this);
                     update(Elist);
                 }
                 else
                 {
                     MessageBox.Show("Усі поля мають бути заповнені");
                 }
             }
             catch
             {
                 MessageBox.Show("Виникла помилка");
             }
        }

        private void Calendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Elist.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "Test filds|*.txt";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(saveFile.FileName, false))
                {
                    foreach (Classes.Events a in Elist2.list)
                    {
                        text = Elist.SaveToFile(a);
                        sw.WriteLine(text);
                    }
                    sw.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                Elist2 = Elist.Filter(textBox1.Text, Elist);
                update2(Elist2);
            }
            else
            {
                update(Elist);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          Elist.Delete(EventsListView);
        }
    }
}
