using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Довідник_фаната_2.Forms
{
    public partial class FormCatalog : Form
    {
        SportmwnsList listi = new SportmwnsList();
        public FormCatalog()
        {
            InitializeComponent();

            //LV propaties
            
            update(listi);
        }

        public FormCatalog(Sportsmen a)
        {
            InitializeComponent();
            listi.Add(a);
            update(listi);
        }


        private void update(SportmwnsList listi)
        {
            //ROW
            String[] row;
            if (listi.list == null)
                //listi.CreateNewList();
            foreach (Sportsmen sp in listi.list)
            {
                row = sp.GetRowStrig();
                ListViewItem item = new ListViewItem(row);
                
            }
   
        }
    }
}
