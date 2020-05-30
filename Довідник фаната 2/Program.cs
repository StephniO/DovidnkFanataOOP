using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace Довідник_фаната_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm()); 
        }

    }
}
