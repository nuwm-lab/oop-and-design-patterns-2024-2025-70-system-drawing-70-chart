﻿using System;
using System.Windows.Forms;

namespace GraphApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Запускаємо форму Form1
        }
    }
} 