//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    /// <summary>
    /// The main class containing the main entry point of the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Export method for manages the system standby.
        /// The flag's value could be 0x00000040, 0x8000000, 0x00000002 or 0x00000001.
        /// </summary>
        /// <param name="flags">A (or multiple) flag(s) that represents if the system standby is activated.</param>
        /// <returns>a value made up from the same flags.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SetThreadExecutionState([In] uint flags);

        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        /// <param name="args">list of entered arguments.</param>
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                Core.Syst.Log.WriteLog(Core.Syst.Log.EType.Normal, "Application started");

                _ = SetThreadExecutionState(0x80000000 | 0x00000002 | 0x00000040);

                if (args.Length > 0)
                {
                    SetUsernamePassword(args);
                }

                Core.Syst.Setting.ImportSettings(@"Settings\AutoSaveSettings.xml");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Controls.MainForm());
            }
            finally
            {
                Core.Syst.Setting.ExportSettingsToXml(Core.Syst.Setting.CurrentSetting, "AutoSaveSettings.xml");

                _ = SetThreadExecutionState(0x80000000);
                Core.Syst.Log.WriteLog(Core.Syst.Log.EType.Normal, "Application stopped");
            }
        }

        /// <summary>
        /// Set the username and password if they were given in the arguments.
        /// </summary>
        /// <param name="args">list of entered arguments.</param>
        private static void SetUsernamePassword(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-u")
                {
                    i++;
                    if (i < args.Length)
                    {
                        Core.Web.WebService.Username = args[i];
                    }
                }
                else if (args[i] == "-p")
                {
                    i++;
                    if (i < args.Length)
                    {
                        Core.Web.WebService.Password = args[i];
                    }
                }
            }
        }
    }
}
