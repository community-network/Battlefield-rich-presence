﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BattlefieldRichPresence
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new TrayItem());
        }

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
