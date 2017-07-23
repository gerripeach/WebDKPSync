using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace $safeprojectname$
{
    public partial class $safeprojectname$ : Form
    {
        List<Player> chars = new List<Player>();

        internal class Player
        {
            public String Class;
            public String Name;
            public String Dkp;
            public bool isMain;
        }

        public $safeprojectname$()
        {
            InitializeComponent();
        }

        private void GDKPSync_Load(object sender, EventArgs e)
        {
            WebRequest req = HttpWebRequest.Create(Properties.Settings.Default.guildURL);
            req.Method = "GET";

            String rawSource;
            using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                rawSource = reader.ReadToEnd();
            }

            String[] source = rawSource.Split('\n');

            bool charFound = false;
            String currentClass = "";
            for (int i = 0; i < source.Length; ++i)
            {
                if (source[i].Contains("<th align=\"center\" nowrap=\"nowrap\" class=\"wowclass"))
                {
                    currentClass = source[i + 4].Split(';')[1].Replace("\r", "");
                }

                if (source[i].Contains("<tr class=\"row1\" valign=\"top\"") || source[i].Contains("<tr class=\"row2\" valign=\"top\""))
                    charFound = true;

                if (charFound)
                {
                    Player player = new Player();
                    player.Name = source[i + 1].Split('>')[1].Split('<')[0];
                    player.Dkp = source[i + 2].Split('>')[1].Split('<')[0];
                    player.Class = currentClass;
                    i += 2;
                    charFound = false;
                    chars.Add(player);
                }
            }
        }

        private void optionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.ShowDialog(this);
        }

        private void button_sync_Click(object sender, EventArgs e)
        {
            string lines = "WebDKP_Log = {\n}\nWebDKP_DkpTable = {\n";
            String line = "";
            foreach (Player p in chars)
            {
                line = "	[\"" + p.Name + "\"] = {\n";
                line += "		[\"gp_1\"] = 1,\n";
                line += "		[\"standby\"] = 0,\n";
                line += "		[\"cantrim\"] = false,\n";
                line += "		[\"dkp_1\"] = " + p.Dkp + ",\n";
                line += "		[\"class\"] = \"" + p.Class + "\",\n";
                line += "		[\"ep_1\"] = 0,\n";
                line += "		[\"Selected\"] = false,\n";
                line += "	},\n";

                lines += line;
            }

            lines += "}\n";
            lines += "WebDKP_Tables = {\n}\n";
            lines += "WebDKP_Loot = {\n}\n";
            lines += "WebDKP_Alts = {\n}\n";
            lines += "WebDKP_WebOptions = {\n";
            lines += "	[\"ZeroSumEnabled\"] = 0,\n";
            lines += "	[\"CombineAlts\"] = 0,\n";
            lines += "}";


            DateTime localDate = DateTime.Now;
            String time = localDate.ToString("yyyy-d-M-HH-mm-ss");
            String luaPath = Properties.Settings.Default.wowPath + "\\WTF\\Account\\" + Properties.Settings.Default.accountName + "\\" +
                "SavedVariables\\WebDKP.lua";
            String backPath = Properties.Settings.Default.wowPath + "\\backup\\" + time + "WebDKP.lua";
            System.IO.Directory.CreateDirectory(Properties.Settings.Default.wowPath + "\\backup\\");

            File.Copy(luaPath, backPath);


            StreamWriter file = new StreamWriter(Properties.Settings.Default.wowPath + "\\WTF\\Account\\" + Properties.Settings.Default.accountName + "\\" +
                "SavedVariables\\WebDKP.lua");
            file.WriteLine(lines);
            file.Close();

            label1.Text = chars.Count + " Datensätze erfolgreich eingetragen. (" + time + ")";
        }

        private void button_modify_Click(object sender, EventArgs e)
        {
            List<List<Player>> accounts = new List<List<Player>>();

            bool accountFound = false;

            String[] source = sourceChars.Text.Split('\n');

            for (int i = 0; i < source.Length; ++i)
            {
                if (source[i].Contains("<tr class=\"row1\">") || source[i].Contains("<tr class=\"row2\">"))
                    accountFound = true;

                if (source[i].Contains("</tr>"))
                {
                    accountFound = false;
                    continue;
                }

                if (accountFound)
                {
                    string expr = "c([1-9]|[0-9][0-9])\">(.*?)</span>";
                    MatchCollection mc = Regex.Matches(source[i], expr);

                    List<Player> account = new List<Player>();
                    if (mc.Count > 0)
                    {
                        foreach (Match m in mc)
                        {
                            String character = m.ToString().Split('>')[1].Split('<')[0];
                            Player player = new Player();
                            player.Name = character;
                            account.Add(player);
                        }
                        accounts.Add(account);
                    }
                }
            }

            foreach (List<Player> acc in accounts)
            {
                foreach (Player p in acc)
                {
                    foreach (Player main in chars)
                    {
                        if (p.Name == main.Name)
                        {
                            p.isMain = true;
                            break;
                        }
                    }
                }
            }

            sourceChars.Text = "";
            foreach (List<Player> acc in accounts)
            {
                foreach (Player p in acc)
                {
                    if (p.isMain)
                        sourceChars.Text += p.Name + "**\r\n";
                    else
                        sourceChars.Text += p.Name + "\r\n";
                }
                sourceChars.Text += "\r\n";
            }

            String sourceExportNew = sourceExport.Text;
            foreach (List<Player> acc in accounts)
            {
                String main = "";
                foreach (Player p in acc)
                {
                    if (p.isMain)
                        main = p.Name;
                }

                foreach (Player p in acc)
                {
                    sourceExportNew = sourceExportNew.Replace(p.Name, main);
                }
            }

            outExport.Text = sourceExportNew;
        }
    }
}
