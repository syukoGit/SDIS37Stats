using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDIS37Stats
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Controls.MainForm());
        }
    }
}
