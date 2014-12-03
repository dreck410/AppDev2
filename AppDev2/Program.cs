﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AppDev2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// this is added by CKost
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            dataBaseConnector.Instance.connect();


            Application.Run(new Form1());
        }
    }
}
