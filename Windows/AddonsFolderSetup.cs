using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spNLauncherArma3.Windows
{
    public partial class AddonsFolderSetup : Form
    {
        private string GameFolder = "";
        public string AddonsFolder { get; set; }

        public AddonsFolderSetup()
        {
            InitializeComponent();

            GameFolder = Properties.Settings.Default.Arma3Folder;
        }

        private void btn_ereaseModsDirectory_Click(object sender, EventArgs e)
        {
            txtb_modsDirectory.Text = "";
            btn_done.Enabled = false;
        }

        private void btn_browseModsDirectory_Click(object sender, EventArgs e)
        {
            dlg_folderBrowser.ShowNewFolderButton = true;

            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (dlg_folderBrowser.SelectedPath != GameFolder)
                {
                    AddonsFolder = dlg_folderBrowser.SelectedPath + @"\";
                    txtb_modsDirectory.Text = dlg_folderBrowser.SelectedPath;

                    btn_done.Enabled = true;
                }
                else
                    MessageBox.Show("The Addons folder can't be the same as the Game folder.\nWe recommend you to have a specific folder for the addons on this launcher to avoid conflicts.", "Wrong directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dlg_folderBrowser.ShowNewFolderButton = false;
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            if(AddonsFolder != "")
                this.Close();
        }

        private void AddonsFolderSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AddonsFolder == "")
                e.Cancel = true;
        }
    }
}
