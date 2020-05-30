using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;


//using System.Collections;

namespace Довідник_фаната_2.Forms
{
    public partial class FormAddNewSpotsmen : Form
    {
        //Поля
        private FormMenu GetForm;
        private int temp;
        public string radioTemp; 
        //Конструтор
        public FormAddNewSpotsmen(FormMenu setForm)
        {
            InitializeComponent();
            GetForm = setForm;
        }

        public FormAddNewSpotsmen(Sportsmen sportsmen, FormMenu f, int t)
        {
            Sportsmen sp = sportsmen;
            InitializeComponent();
            textBox1.Text = sp.SecName;
            textBox2.Text = sp.Name;
            textBox3.Text = sp.ThirdName;
            textBox4.Text = sp.Country;
            textBox5.Text = sp.Gromad;
            dateTimePicker1.Value = sp.Datetime;
            if (sp.Sex == "жінка") radioButton1.Select();
            else radioButton2.Select();
            textBox9.Text = sp.Weight.ToString();
            textBox8.Text = sp.Hight.ToString();
            textBox10.Text = sp.Sport;
            textBox11.Text = sp.Team;
            textBox12.Text = sp.AddiInfo;
            GetForm = f;
            temp = t;
        }

        //методи

        //метод витирання усіх текстових полів
        private static void CleanAllTextBoxesIn(Control parent)
        {
            foreach (Control item in parent.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                    item.Text = string.Empty;

                if (item.GetType() == typeof(GroupBox))
                    CleanAllTextBoxesIn(item);
            }
        }

        //Кнопки
        //Додавання нового спортсменa
        private void btnAdd_Click(object sender, EventArgs e)
        {            
            try
            {
               Sportsmen sportsmen = AddSportsmen();
               GetForm.spmList.Add(sportsmen);
               MessageBox.Show("Реєстрація пройшла успішно");
               CleanAllTextBoxesIn(this);
           }
           catch (Exception ex)
           {
               MessageBox.Show("Усі поля мають бути заповнені. Вага та зріст не можуть бути менше 10", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           this.Close();
        }


        public Sportsmen AddSportsmen()
        {
            Sportsmen sportsmen = new Sportsmen(textBox1.Text, textBox2.Text, textBox3.Text,
                                                     textBox4.Text, textBox5.Text, dateTimePicker1.Value,
                                                     radioTemp, textBox10.Text, textBox11.Text, textBox12.Text, 
                                                     double.Parse(textBox8.Text), double.Parse(textBox9.Text));
            return sportsmen;
        }
        //Очищення текстбоксів
        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanAllTextBoxesIn(this);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioTemp = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioTemp = radioButton2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Sportsmen sportsmen = AddSportsmen();
                GetForm.spmList.list[temp]=sportsmen;
                MessageBox.Show("Оновлено успішно");
                CleanAllTextBoxesIn(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Усі поля мають бути заповнені", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
        
    }
}
