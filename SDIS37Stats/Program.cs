using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SDIS37Stats
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SetThreadExecutionState([In] uint esFlags);


        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                SetThreadExecutionState(0x80000000 | 0x00000002 | 0x00000040);

                if(args.Length > 0)
                {
                    SetUsernamePassword(args);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Controls.MainForm());
            }
            finally
            {
                SetThreadExecutionState(0x80000000);
                Console.Out.WriteLine("Arrêt du programme");
            }
        }

        static void SetUsernamePassword(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-u")
                {
                    i++;
                    if (i < args.Length)
                    {
                        Core.Web.WebService.Username = args[i];
                        Console.Out.WriteLine("Username : " + args[i]);
                    }
                }
                else if (args[i] == "-p")
                {
                    i++;
                    if (i < args.Length)
                    {
                        Core.Web.WebService.Password = args[i];
                        Console.Out.WriteLine("Password : " + args[i]);
                    }
                }
            }
        }
    }
}
