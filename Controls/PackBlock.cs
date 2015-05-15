using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace spNLauncherArma3.Controls
{
    public partial class PackBlock : UserControl
    {
        public PackBlock(string title, string content, string linktitle, string url, string label)
        {
            InitializeComponent();

            txt_title.Text = title;
        }
    }
}
