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

namespace Довідник_фаната_2
{

    public partial class FormMenu : Form
    {
        //Поля
        public SportmwnsList spmList = new SportmwnsList();
        public SportmwnsList spmList2 = new SportmwnsList();
        private Button currentButton;
        private Random random;
        private int tempIndex;
        //private Form activForm; 
        //public ListView sportsmenlistview;

        //Конструктор
        public FormMenu()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            sportsmenListVie.View = View.Details;
            sportsmenListVie.FullRowSelect = true;
            ActivateButton(btnCatalog);
            Cleare();
            if (spmList != null)
            {
                update(spmList);
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        //Методи

        //Комбобокс


        //Листвью
        //Заповнення Листвью
        private void update(SportmwnsList listi)
        {
            Cleare();
            //ROW
            String[] row;
            if (listi.list != null)
            {
                foreach (Sportsmen sp in listi.list)
                {
                    row = sp.GetRowStrig();
                    ListViewItem item = new ListViewItem(row);
                    sportsmenListVie.Items.Add(item);
                }
            }
            spmList2 = spmList;
        }
        private void update2(SportmwnsList listi)
        {
            Cleare();
            //ROW
            String[] row;
            if (listi.list != null)
            {
                foreach (Sportsmen sp in listi.list)
                {
                    row = sp.GetRowStrig();
                    ListViewItem item = new ListViewItem(row);
                    sportsmenListVie.Items.Add(item);
                }
            }
        }

        //видалення листьвю
        private void Cleare()
        {
            sportsmenListVie.Items.Clear();
        }

        //Кнопки
        //конопки меню
        private void btnCatalog_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            update(spmList);
        }

        private void btnAddNewSportmen_Click(object sender, EventArgs e)
        {
            ActivateButton(btnAddNewSportmen);
            Forms.FormAddNewSpotsmen form = new Forms.FormAddNewSpotsmen(this);
            form.ShowDialog();
            update(spmList);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            Forms.Calendar a = new Forms.Calendar(spmList);
            a.ShowDialog();
        }

        //Кнопки на формі
        //Зберігання спорсменів
        private void Downloadbtn_Click(object sender, EventArgs e)
        {
            string text;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "Test filds|*.txt";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length>0)
            {
                using (StreamWriter sw = new StreamWriter(saveFile.FileName, false))
                {
                    foreach (Sportsmen a in spmList2.list)
                    {
                        text = spmList.SaveToFile(a);
                        sw.WriteLine(text);                        
                    }
                    sw.Close();
                }
            }            
        }

        //командні кнопки
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMaxSize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void buttonMiniSize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //обирання рандомного кольору
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        //підсвічення активної кнопки
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft YaHei", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    panelTop.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    menuStrip.BackColor = color;
                    ThemeColor.PrimariColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        //дизактивація кнопки
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
            }
        }
        //меню
        private void menuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //панель перетаскування
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Reset()
        {
            DisableButton();
            panelTop.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(0, 129, 127);
            menuStrip.BackColor = Color.FromArgb(0, 150, 136);
            currentButton = null;
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spmList.Save();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spmList = spmList.Open();
            update(spmList);
        }

        //видалення 
        private void button1_Click(object sender, EventArgs e)
        {
            spmList.Delete(sportsmenListVie);
        }

        //відновити
        private void button2_Click(object sender, EventArgs e)
        {
            int temp = spmList.Update(sportsmenListVie);
            if (temp != -1)
            {
                Sportsmen s = spmList.list[temp];
                Forms.FormAddNewSpotsmen form = new Forms.FormAddNewSpotsmen(s, this, temp);
                form.ShowDialog();
                update(spmList);
            }
        }

        //фільтр
        private void button4_Click(object sender, EventArgs e)
        {
            spmList2 = spmList.Find(spmList, txtSurn.Text, txtName.Text, txtCount.Text, txtSport.Text);
            update2(spmList2);
        }
    }
}
