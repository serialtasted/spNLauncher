﻿using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Xml;
using System.Windows.Forms;
//using System.Drawing;
using System.Reflection;
//using System.Threading;
using System.IO;

namespace spNLauncherArma3.Workers
{
    class zCheckUpdate
    {
        private readonly Button btn_Update;
        private readonly Label txt_Cur;
        private readonly Label txt_New;
        private readonly PictureBox pic_busy;

        private readonly Label txt_versiontag;

        private string urlversionxml = Properties.GlobalValues.S_VersionXML;
        //private string zversionxml = Application.StartupPath + @"\zversion.xml";

        public zCheckUpdate() { }

        public zCheckUpdate(Label VersionTag)
        {
            txt_versiontag = VersionTag;
        }

        public zCheckUpdate(Button BtnUpdate, Label TxtCurVersion, Label TxtNewVersion, PictureBox PicBusy)
        {
            btn_Update = BtnUpdate;
            txt_Cur = TxtCurVersion;
            txt_New = TxtNewVersion;
            pic_busy = PicBusy;
        }

        public bool QuickCheck()
        {
            Version NewVersion = null;
            Version CurVersion = null;

            bool ContinueStart = false;

            string NewVersionS = "";
            string CurVersionS = "";
            string aux_vBuild = "";

            try
            {
                try
                {
                    #region NewUpdateXmlInfo
                    XmlDocument NewUpdateXmlInfo = new XmlDocument();
                    NewUpdateXmlInfo.Load(urlversionxml);

                    int new_versionmajor = Convert.ToInt32(NewUpdateXmlInfo.SelectSingleNode("//spN_Launcher//LauncherInfo//Version").Attributes["major"].Value);
                    int new_versionminor = Convert.ToInt32(NewUpdateXmlInfo.SelectSingleNode("//spN_Launcher//LauncherInfo//Version").Attributes["minor"].Value);
                    int new_versionbuild = Convert.ToInt32(NewUpdateXmlInfo.SelectSingleNode("//spN_Launcher//LauncherInfo//Version").Attributes["build"].Value);
                    string new_versiontag = NewUpdateXmlInfo.SelectSingleNode("//spN_Launcher//LauncherInfo//Version").Attributes["tag"].Value;

                    NewVersion = new Version(new_versionmajor, new_versionminor, new_versionbuild);
                    #endregion

                    if (NewVersion.Build != 0)
                        aux_vBuild = "." + NewVersion.Build;
                    else
                        aux_vBuild = "";

                    if (new_versiontag != "")
                        NewVersionS = NewVersion.Major + "." + NewVersion.Minor + aux_vBuild + " (" + new_versiontag + ")";
                    else
                        NewVersionS = NewVersion.Major + "." + NewVersion.Minor + aux_vBuild;
                }
                catch (Exception NewEx)
                {
                    
                }

                try
                {
                    #region CurVersionInfo
                    int cur_versionmajor = Assembly.GetExecutingAssembly().GetName().Version.Major;
                    int cur_versionminor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
                    int cur_versionbuild = Assembly.GetExecutingAssembly().GetName().Version.Build;
                    string cur_versiontag = Properties.GlobalValues.S_VersionTag;

                    CurVersion = new Version(cur_versionmajor, cur_versionminor, cur_versionbuild);
                    #endregion

                    if (CurVersion.Build != 0)
                        aux_vBuild = "." + CurVersion.Build;
                    else
                        aux_vBuild = "";

                    txt_versiontag.Text = cur_versiontag;

                    if (cur_versiontag != "")
                        CurVersionS = CurVersion.Major + "." + CurVersion.Minor + aux_vBuild + " (" + cur_versiontag + ")";
                    else
                        CurVersionS = CurVersion.Major + "." + CurVersion.Minor + aux_vBuild;
                }
                catch (Exception CurEx)
                {
                    txt_versiontag.Text = "Unable to determinate installed version.";
                }

                if (NewVersion > CurVersion)
                {
                    if (MessageBox.Show("There's a new launcher version available.\n • \"OK\" to update.\n • \"Cancel\" to continue.", "Version " + NewVersionS + " available", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    { ContinueStart = false; }
                    else
                    { ContinueStart = true; }

                    txt_versiontag.Text = "Version " + NewVersionS + " available to update!";
                }
                else if (NewVersion < CurVersion)
                {
                    //MessageBox.Show("A tua versão é superior à última versão disponível. Esta é uma situação estranha, mas pode acontecer às vezes.", "That awkward moment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ContinueStart = true;
                }
                else
                {
                    ContinueStart = true;
                }
            }
            catch (Exception AllEx)
            {
                ContinueStart = true;
            }

            return ContinueStart;
        }

        public void CheckUpdates()
        {
            Version NewVersion = null;
            Version CurVersion = null;
            string aux_vBuild = "";

            try
            {
                try
                {
                    #region NewUpdateXmlInfo
                    XmlDocument NewUpdateXmlInfo = new XmlDocument();
                    NewUpdateXmlInfo.Load(urlversionxml);

                    int new_versionmajor = Convert.ToInt32(NewUpdateXmlInfo.SelectSingleNode("//spN_Launcher//LauncherInfo//Version").Attributes["major"].Value);
                    int new_versionminor = Convert.ToInt32(NewUpdateXmlInfo.SelectSingleNode("//spN_Launcher//LauncherInfo//Version").Attributes["minor"].Value);
                    int new_versionbuild = Convert.ToInt32(NewUpdateXmlInfo.SelectSingleNode("//spN_Launcher//LauncherInfo//Version").Attributes["build"].Value);
                    string new_versiontag = NewUpdateXmlInfo.SelectSingleNode("//spN_Launcher//LauncherInfo//Version").Attributes["tag"].Value;

                    NewVersion = new Version(new_versionmajor, new_versionminor, new_versionbuild);
                    #endregion

                    if (NewVersion.Build != 0)
                        aux_vBuild = "." + NewVersion.Build;
                    else
                        aux_vBuild = "";

                    if (new_versiontag != "")
                        txt_New.Text = NewVersion.Major + "." + NewVersion.Minor + aux_vBuild + " (" + new_versiontag + ")";
                    else
                        txt_New.Text = NewVersion.Major + "." + NewVersion.Minor + aux_vBuild;
                }
                catch (Exception NewEx)
                {
                    txt_New.Text = "Unable to get information from the server!";
                    btn_Update.Enabled = false;
                }

                try
                {
                    #region CurVersionXmlInfo
                    int cur_versionmajor = Assembly.GetExecutingAssembly().GetName().Version.Major;
                    int cur_versionminor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
                    int cur_versionbuild = Assembly.GetExecutingAssembly().GetName().Version.Build;
                    string cur_versiontag = Properties.GlobalValues.S_VersionTag;

                    CurVersion = new Version(cur_versionmajor, cur_versionminor, cur_versionbuild);
                    #endregion

                    if (CurVersion.Build != 0)
                        aux_vBuild = "." + CurVersion.Build;
                    else
                        aux_vBuild = "";

                    if (cur_versiontag != "")
                        txt_Cur.Text = CurVersion.Major + "." + CurVersion.Minor + aux_vBuild + " (" + cur_versiontag + ")";
                }
                catch (Exception CurEx)
                {
                    txt_Cur.Text = "Unable to determinate installed version";
                    btn_Update.Enabled = false;
                }

                if (NewVersion > CurVersion)
                { btn_Update.Enabled = true; }
                else if (NewVersion < CurVersion)
                { btn_Update.Enabled = false; }
                else if (NewVersion == CurVersion)
                { btn_Update.Enabled = true; btn_Update.Text = "Reinstall"; }
            }
            catch (Exception AllEx)
            {
                btn_Update.Enabled = false;

                if (System.Diagnostics.Debugger.IsAttached)
                    MessageBox.Show(AllEx.Message);
            }
            finally
            {
                pic_busy.Visible = false;
            }
        }
    }
}
