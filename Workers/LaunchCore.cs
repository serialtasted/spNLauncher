using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spNLauncherArma3.Workers
{
    class LaunchCore
    {
        private string GameFolder = Properties.Settings.Default.Arma3Folder;
        private string AddonsFolder = Properties.Settings.Default.AddonsFolder;
        private string TSFolder = Properties.Settings.Default.TS3Folder;
        private string Arguments = "";

        public LaunchCore(bool noLogs,
            bool noPause,
            bool noSplash,
            bool noCB,
            bool enableHT,
            bool skipIntro,
            bool window,
            bool winxp,
            bool showScriptErrors,
            bool noBenchmark,
            bool world,
            string s_world,
            bool maxMem,
            string s_maxMem,
            bool malloc,
            string s_malloc,
            bool maxVRAM,
            string s_maxVRAM,
            bool exThreads,
            string s_exThreads,
            bool cpuCount,
            string s_cpuCount)
        {
            string auxCombinedArguments = AggregateArguments(noLogs, noPause, noSplash, noCB, enableHT, skipIntro, window, winxp,
                showScriptErrors, noBenchmark, world, s_world, maxMem, s_maxMem, malloc, s_malloc, maxVRAM, s_maxVRAM, exThreads, s_exThreads, cpuCount, s_cpuCount);

            if (auxCombinedArguments != "") Arguments = auxCombinedArguments.Remove(auxCombinedArguments.Length - 1);
        }

        public LaunchCore(bool noLogs, 
            bool noPause, 
            bool noSplash, 
            bool noCB, 
            bool enableHT, 
            bool skipIntro, 
            bool window, 
            bool winxp, 
            bool showScriptErrors, 
            bool noBenchmark,
            bool world,
            string s_world, 
            bool maxMem,
            string s_maxMem, 
            bool malloc,
            string s_malloc, 
            bool maxVRAM,
            string s_maxVRAM, 
            bool exThreads,
            string s_exThreads, 
            bool cpuCount,
            string s_cpuCount,
            bool jsrs,
            string s_jsrs,
            bool blastcore,
            string s_blastcore,
            ListBox activeAddons,
            List<string> modsList)
        {
            string auxCombinedArguments = AggregateArguments(noLogs, noPause, noSplash, noCB, enableHT, skipIntro, window, winxp, 
                showScriptErrors, noBenchmark, world, s_world, maxMem, s_maxMem, malloc, s_malloc, maxVRAM, s_maxVRAM, exThreads, s_exThreads, cpuCount, s_cpuCount);
            string auxCombinedAddons = "";
            string auxCoreMods = "-mod=\"";
            int i = 0;

            if (auxCombinedArguments != "") Arguments = auxCombinedArguments.Remove(auxCombinedArguments.Length - 1);

            if (jsrs)
                auxCombinedAddons = ";" + AddonsFolder + s_jsrs;

            if (blastcore)
                if (auxCombinedAddons != "")
                    auxCombinedAddons = auxCombinedAddons + ";" + AddonsFolder + s_blastcore;
                else
                    auxCombinedAddons = ";" + AddonsFolder + s_blastcore;

            //MessageBox.Show(s_modsFolder);

            if (activeAddons.Items.Count > 0)
            {
                do
                {
                    if (auxCombinedAddons != "") auxCombinedAddons = auxCombinedAddons + ";" + AddonsFolder + activeAddons.Items[i].ToString();
                    else auxCombinedAddons = ";" + AddonsFolder + activeAddons.Items[i].ToString();
                    i++;
                } while (i != activeAddons.Items.Count);
            }

            foreach (string mod in modsList)
            {
                if (mod != null)
                    if (auxCoreMods != "-mod=\"")
                        auxCoreMods = auxCoreMods + ";" + AddonsFolder + mod;
                    else
                        auxCoreMods = auxCoreMods + AddonsFolder + mod;
                else
                    break;
            }

            if (Arguments != "") Arguments = Arguments + " " + auxCoreMods + auxCombinedAddons + "\"";
            else Arguments = auxCoreMods + auxCombinedAddons;

            //MessageBox.Show(Arguments);
        }

        private string AggregateArguments(bool noLogs,
            bool noPause,
            bool noSplash,
            bool noCB,
            bool enableHT,
            bool skipIntro,
            bool window,
            bool winxp,
            bool showScriptErrors,
            bool noBenchmark,
            bool world,
            string s_world,
            bool maxMem,
            string s_maxMem,
            bool malloc,
            string s_malloc,
            bool maxVRAM,
            string s_maxVRAM,
            bool exThreads,
            string s_exThreads,
            bool cpuCount,
            string s_cpuCount)
        {
            string auxCombinedArguments = "";

            if (noLogs) auxCombinedArguments = auxCombinedArguments + "-noLogs ";
            if (noPause) auxCombinedArguments = auxCombinedArguments + "-noPause ";
            if (noSplash) auxCombinedArguments = auxCombinedArguments + "-noSplash ";
            if (noCB) auxCombinedArguments = auxCombinedArguments + "-noCB ";
            if (enableHT) auxCombinedArguments = auxCombinedArguments + "-enableHT ";
            if (skipIntro) auxCombinedArguments = auxCombinedArguments + "-skipIntro ";
            if (window) auxCombinedArguments = auxCombinedArguments + "-window ";
            if (winxp) auxCombinedArguments = auxCombinedArguments + "-winxp ";
            if (showScriptErrors) auxCombinedArguments = auxCombinedArguments + "-showScriptErrors ";
            if (noBenchmark) auxCombinedArguments = auxCombinedArguments + "-noBenchmark ";

            if (world && s_world != "") auxCombinedArguments = auxCombinedArguments + "-world=" + s_world + " ";
            if (maxMem && s_maxMem != "") auxCombinedArguments = auxCombinedArguments + "-maxMem=" + s_maxMem + " ";
            if (malloc && s_malloc != "") auxCombinedArguments = auxCombinedArguments + "-malloc=" + s_malloc + " ";
            if (maxVRAM && s_maxVRAM != "") auxCombinedArguments = auxCombinedArguments + "-maxVRAM=" + s_maxVRAM + " ";
            if (exThreads && s_exThreads != "") auxCombinedArguments = auxCombinedArguments + "-exThreads=" + s_exThreads + " ";
            if (cpuCount && s_cpuCount != "") auxCombinedArguments = auxCombinedArguments + "-cpuCount=" + s_cpuCount + " ";

            return auxCombinedArguments;
        }

        public string GetArguments()
        {
            return Arguments;
        }
        
        public bool isModPackInstalled(List<string> modsList)
        {
            bool aux_isAll = false;

            foreach (string mod in modsList)
            {
                if (mod != null)
                    foreach (string d in Directory.GetDirectories(AddonsFolder))
                    {
                        if (d.Contains(mod)) { aux_isAll = true; break; }
                        else { aux_isAll = false; continue; }
                    }
                else
                    break;

                if (!aux_isAll)
                    break;
            }

            if (aux_isAll) return true;
            else return false;
        }

        public void LaunchGame(string Arguments, Form mainForm, Label Status, PictureBox Launch, string serverip, string serverport, string password)
        {
            string aux_Arguments = "";
            Ping ping = new Ping();

            if (serverip != "" && serverport != "")
            {
                PingReply pingresult = ping.Send(serverip);
                if (pingresult.Status == IPStatus.Success)
                {
                    if (password != "")
                        aux_Arguments = "-connect=" + serverip + " -port=" + serverport + " -password=\"" + password + "\" " + Arguments;
                    else
                        aux_Arguments = "-connect=" + serverip + " -port=" + serverport + " " + Arguments;
                }
                else
                {
                    aux_Arguments = Arguments;
                }
            }
            else
                aux_Arguments = Arguments;

            //Clipboard.SetText(aux_Arguments);

            try
            {
                var fass = new ProcessStartInfo();
                fass.WorkingDirectory = TSFolder;

                if (File.Exists(TSFolder + "ts3client_win64.exe"))
                    fass.FileName = "ts3client_win64.exe";

                if (File.Exists(TSFolder + "ts3client_win32.exe"))
                    fass.FileName = "ts3client_win32.exe";

                var process = new Process();
                process.StartInfo = fass;

                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                var fass = new ProcessStartInfo();
                fass.WorkingDirectory = GameFolder;
                fass.FileName = "arma3.exe";
                fass.Arguments = aux_Arguments;

                var process = new Process();
                process.StartInfo = fass;
                process.Start();

                Thread.Sleep(500);

                GC.Collect();

                Status.Text = "Game running...";
                Launch.Enabled = false;
                mainForm.Hide();
                process.WaitForExit();
                mainForm.Show();
                Launch.Enabled = true;
                Status.Text = "Waiting for orders...";

                //MessageBox.Show("Iniciou");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
    }
}
