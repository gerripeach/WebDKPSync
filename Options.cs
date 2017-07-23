using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace $safeprojectname$
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();

            wowPath.Text = Properties.Settings.Default.wowPath;
            guildURL.Text = Properties.Settings.Default.guildURL;
            accountName.Text = Properties.Settings.Default.accountName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.wowPath = Properties.Settings.Default.wowPathDefault;
            wowPath.Text = Properties.Settings.Default.wowPathDefault;

            Properties.Settings.Default.guildURL = Properties.Settings.Default.guildURLDefault;
            guildURL.Text = Properties.Settings.Default.guildURLDefault;

            Properties.Settings.Default.accountName = Properties.Settings.Default.accountNameDefault;
            accountName.Text = Properties.Settings.Default.accountNameDefault;

            Properties.Settings.Default.Save();
        }

        private void addonPath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.wowPath = wowPath.Text;
            Properties.Settings.Default.Save();
        }

        private void guildURL_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.guildURL = guildURL.Text;
            Properties.Settings.Default.Save();
        }

        private void accountName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.accountName = accountName.Text;
            Properties.Settings.Default.Save();
        }
    }
}
