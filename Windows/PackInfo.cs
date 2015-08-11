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
    public partial class PackInfo : Form
    {
        public PackInfo(string Title, string Content)
        {
            InitializeComponent();
            txt_title.Text = Title;
            txt_content.Text = Content;

            setsize();
        }

        private void setsize()
        {
            if (txt_content.Height > 57)
                this.Height = txt_content.Height + 80;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_close_MouseHover(object sender, EventArgs e)
        {
            btn_close.Image = Properties.Resources.close_hover;
        }

        private void btn_close_MouseLeave(object sender, EventArgs e)
        {
            btn_close.Image = Properties.Resources.close;
        }
    }
}
