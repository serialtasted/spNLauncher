using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using spNLauncherArma3.Workers;
using System.IO;

namespace spNLauncherArma3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (File.Exists("zUpdator.exe"))
                File.Delete("zUpdator.exe");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!SingleInstance.Start())
            {
                SingleInstance.ShowFirstInstance();
                return;
            }

            Application.Run(new MainForm());

            SingleInstance.Stop();
        }
    }
}
