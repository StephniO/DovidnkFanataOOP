using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Довідник_фаната_2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string pass = "100ballov";
            string login = "Fanat";
            if (textBox1.Text==pass&&textBox2.Text==login)
            {
                this.Hide();
                FormMenu a = new FormMenu();
                a.Show();
            }
            else
            {
                MessageBox.Show("Логін або пароль були введені неправильно");
            }
        }
    }
}
