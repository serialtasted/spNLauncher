using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace spNLauncherArma3.Workers
{
    class FecthAddonPacks
    {
        MainForm formMain;
        private readonly ToolStripMenuItem menuAddons;

        public FecthAddonPacks(ToolStripMenuItem menu_AddonPacks, MainForm mainForm)
        {
            formMain = mainForm;
            menuAddons = menu_AddonPacks;
        }
        public void Get ()
        {
            try
            {
                menuAddons.DropDownItems.Clear();

                XmlDocument RemoteXmlInfo = new XmlDocument();
                RemoteXmlInfo.Load(Properties.GlobalValues.S_VersionXML);

                XmlNodeList xnl = RemoteXmlInfo.SelectNodes("//spN_Launcher//ModSets//pack");
                foreach (XmlNode xn in xnl)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem(xn.Attributes["id"].Value);
                    menuItem.Click += MenuItem_Click;

                    if (menuItem.Text == Properties.Settings.Default.lastAddonPack)
                        menuItem.Checked = true;

                    menuAddons.DropDownItems.Add(menuItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in ((ToolStripMenuItem)sender).GetCurrentParent().Items)
            {
                if (item == sender)
                {
                    item.Checked = true;

                    Properties.Settings.Default.lastAddonPack = item.Text;
                    Properties.Settings.Default.Save();
                }
                if ((item != null) && (item != sender))
                {
                    item.Checked = false;
                }
            }

            formMain.FetchRemoteSettings();
            formMain.GetAddons();
        }
    }
}
