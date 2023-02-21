using NetFwTypeLib;
using NetLimiter.Service;
using NLMMB.Src;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NLLM;

namespace NLMMB
{
    public partial class Form1 : Form
    {
        [DllImport("ntdll.dll")]
        private static extern int NtSuspendProcess(IntPtr ProcessHandle);

        [DllImport("ntdll.dll")]
        private static extern int NtResumeProcess(IntPtr ProcessHandle);

        readonly NLClient client = new NLClient();
        readonly FormOverlay frm = new FormOverlay();
        readonly FormUtility frm1 = new FormUtility();
        readonly Settings1 settings = new Settings1();
        readonly HotkeyManager hotkeyManager = new HotkeyManager();

        public ColorDialog dlg = new ColorDialog();
        public ColorDialog dlg1 = new ColorDialog();
        public ColorDialog dlg2 = new ColorDialog();
        public ColorDialog dlg3 = new ColorDialog();
        public ColorDialog dlg4 = new ColorDialog();
        public ColorDialog dlg5 = new ColorDialog();
        public ColorDialog dlg6 = new ColorDialog();
        public ColorDialog dlg7 = new ColorDialog();
        public ColorDialog dlg8 = new ColorDialog();
        public ColorDialog dlg9 = new ColorDialog();
        public ColorDialog dlg10 = new ColorDialog();
        public ColorDialog dlg11 = new ColorDialog();
        public ColorDialog dlg12 = new ColorDialog();
        public ColorDialog dlg13 = new ColorDialog();
        public ColorDialog dlg14 = new ColorDialog();
        public ColorDialog dlg15 = new ColorDialog();
        public ColorDialog dlg16 = new ColorDialog();
        public ColorDialog dlg17 = new ColorDialog();
        public ColorDialog dlg18 = new ColorDialog();
        public ColorDialog dlg19 = new ColorDialog();
        public ColorDialog dlg20 = new ColorDialog();
        public ColorDialog dlg21 = new ColorDialog();
        public ColorDialog dlg22 = new ColorDialog();
        public ColorDialog dlg23 = new ColorDialog();
        public ColorDialog dlg24 = new ColorDialog();
        public ColorDialog dlg25 = new ColorDialog();
        public ColorDialog dlg26 = new ColorDialog();

        bool chk;
        bool chk1;
        bool chk2;
        bool chk3;

        bool mousedown;

        public Form1()
        {
            InitializeComponent();
            try
            {
                client.Connect();
            }
            catch (Exception)
            {
                MessageBox.Show("Download Net Limiter");
                Environment.Exit(0);
            }

            new D2FilterRule(client, settings.AppPath, "Destiny 2", RuleDir.In, settings.bpslfg, 80, 30010);
            new D2FilterRule(client, settings.AppPath, "3074 Down", RuleDir.In, settings.dlbps3074, 3074, 3074);
            new D2FilterRule(client, settings.AppPath, "3074 Up", RuleDir.Out, settings.ulbps3074, 3074, 3074);
            new D2FilterRule(client, settings.AppPath, "7500 Down", RuleDir.In, settings.dlbps7500, 7500, 7509);
            new D2FilterRule(client, settings.AppPath, "7500 Up", RuleDir.Out, settings.ulbps7500, 7500, 7509);
            new D2FilterRule(client, settings.AppPath, "27k Down", RuleDir.In, settings.dlbps27k, 27000, 27200);
            new D2FilterRule(client, settings.AppPath, "27k Up", RuleDir.Out, settings.ulbps27k, 27000, 27200);
            new D2FilterRule(client, settings.AppPath, "30k", RuleDir.In, settings.bps30k, 30000, 30010);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (settings.hotkeydl3074 == true)
            {
                RegisterButtonHotkey(button1, settings.modkeydl3074, settings.keydl3074, settings.hotkeydl3074);
            }
            if (settings.hotkeyul3074 == true)
            {
                RegisterButtonHotkey(button2, settings.modkeyul3074, settings.keyul3074, settings.hotkeyul3074);
            }
            if (settings.hotkeydl7500 == true)
            {
                RegisterButtonHotkey(button3, settings.modkeydl7500, settings.keydl7500, settings.hotkeydl7500);
            }
            if (settings.hotkeyul7500 == true)
            {
                RegisterButtonHotkey(button4, settings.modkeyul7500, settings.keyul7500, settings.hotkeyul7500);
            }
            if (settings.hotkeydl27k == true)
            {
                RegisterButtonHotkey(button5, settings.modkeydl27k, settings.keydl27k, settings.hotkeydl27k);
            }
            if (settings.hotkeyul27k == true)
            {
                RegisterButtonHotkey(button6, settings.modkeyul27k, settings.keyul27k, settings.hotkeyul27k);
            }
            if (settings.hotkeygp == true)
            {
                RegisterButtonHotkey(button8, settings.modkeygp, settings.keygp, settings.hotkeygp);
            }
            if (settings.hotkeypvpl == true)
            {
                RegisterButtonHotkey(button9, settings.modkeypvpl, settings.keypvpl, settings.hotkeypvpl);
            }
            if (settings.hotkey30kkc == true)
            {
                RegisterButtonHotkey(button10, settings.modkey30kkc, settings.key30kkc, settings.hotkey30kkc);
            }
            if (settings.hotkeylfg == true)
            {
                RegisterButtonHotkey(button11, settings.modkeylfg, settings.keylfg, settings.hotkeylfg);
            }
            if (settings.hotkeypvel == true)
            {
                RegisterButtonHotkey(button12, settings.modkeypvel, settings.keypvel, settings.hotkeypvel);
            }
            if (settings.hotkey30kl == true)
            {
                RegisterButtonHotkey(button13, settings.modkey30kl, settings.key30kl, settings.hotkey30kl);
            }

            GetSettings();

            frm.Show();
            frm.Hide();

            Refresh();
        }

        public void GetSettings()
        {
            button1.BackColor = settings.dlbg3074;
            button1.ForeColor = settings.dlfg3074;
            button2.BackColor = settings.ulbg3074;
            button2.ForeColor = settings.ulfg3074;
            button3.BackColor = settings.dlbg7500;
            button3.ForeColor = settings.dlfg7500;
            button4.BackColor = settings.ulbg7500;
            button4.ForeColor = settings.ulfg7500;
            button5.BackColor = settings.dlbg27k;
            button5.ForeColor = settings.dlfg27k;
            button6.BackColor = settings.ulbg27k;
            button6.ForeColor = settings.ulfg27k;
            button7.BackColor = settings.bgd2ol;
            button7.ForeColor = settings.fgd2ol;
            button8.BackColor = settings.bggp;
            button8.ForeColor = settings.fggp;
            button9.BackColor = settings.bgpvp;
            button9.ForeColor = settings.fgpvp;
            button10.BackColor = settings.bg30kkc;
            button10.ForeColor = settings.fg30kkc;
            button11.BackColor = settings.bglfg;
            button11.ForeColor = settings.fglfg;
            button12.BackColor = settings.bghpved;
            button12.ForeColor = settings.fgpvp;
            button13.BackColor = settings.bg30k;
            button13.ForeColor = settings.fg30k;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "3074 Down");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                button1.BackColor = Color.Red;
                client.UpdateRule(rule);
                frm.SetLabel5Color(Color.Red);
                frm.StartStopwatch();
            }
            else
            {
                rule.IsEnabled = false;
                button1.BackColor = dlg1.Color;
                button1.BackColor = Settings1.Default.dlbg3074;
                client.UpdateRule(rule);
                frm.SetLabel5Color(dlg1.Color);
                frm.SetLabel5Color(Settings1.Default.dlbg3074);
                frm.ResetStopwatch();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            {
                var filter = client.Filters.Find(x => x.Name == "3074 Up");
                var rule = client.Rules.Find(x => x.FilterId == filter.Id);

                if (rule.IsEnabled != true)
                {
                    rule.IsEnabled = true;
                    button2.BackColor = Color.Red;
                    client.UpdateRule(rule);
                    frm.SetLabel6Color(Color.Red);
                    frm.StartStopwatch();
                }
                else
                {
                    rule.IsEnabled = false;
                    button2.BackColor = dlg3.Color;
                    button2.BackColor = Settings1.Default.ulbg3074;
                    client.UpdateRule(rule);
                    frm.SetLabel6Color(dlg3.Color);
                    frm.SetLabel6Color(Settings1.Default.ulbg3074);
                    frm.ResetStopwatch();
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "7500 Down");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                button3.BackColor = Color.Red;
                client.UpdateRule(rule);
                frm.SetLabel7Color(Color.Red);
                frm.StartStopwatch();
            }
            else
            {
                rule.IsEnabled = false;
                button3.BackColor = dlg5.Color;
                button3.BackColor = Settings1.Default.dlbg7500;
                client.UpdateRule(rule);
                frm.SetLabel7Color(dlg5.Color);
                frm.SetLabel7Color(Settings1.Default.dlbg7500);
                frm.ResetStopwatch();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "7500 Up");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                button4.BackColor = Color.Red;
                client.UpdateRule(rule);
                frm.SetLabel8Color(Color.Red);
                frm.StartStopwatch();
            }
            else
            {
                rule.IsEnabled = false;
                button4.BackColor = dlg7.Color;
                button4.BackColor = Settings1.Default.ulbg7500;
                client.UpdateRule(rule);
                frm.SetLabel8Color(dlg7.Color);
                frm.SetLabel8Color(Settings1.Default.ulbg7500);
                frm.ResetStopwatch();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "27k Down");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                button5.BackColor = Color.Red;
                client.UpdateRule(rule);
                frm.SetLabel9Color(Color.Red);
                frm.StartStopwatch();
            }
            else
            {
                rule.IsEnabled = false;
                button5.BackColor = dlg9.Color;
                button5.BackColor = Settings1.Default.dlbg27k;
                client.UpdateRule(rule);
                frm.SetLabel9Color(dlg9.Color);
                frm.SetLabel9Color(Settings1.Default.dlbg27k);
                frm.ResetStopwatch();
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "27k Up");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                button6.BackColor = Color.Red;
                client.UpdateRule(rule);
                frm.SetLabel10Color(Color.Red);
                frm.StartStopwatch();
            }
            else
            {
                rule.IsEnabled = false;
                button6.BackColor = dlg11.Color;
                button6.BackColor = Settings1.Default.ulbg27k;
                client.UpdateRule(rule);
                frm.SetLabel10Color(dlg11.Color);
                frm.SetLabel10Color(Settings1.Default.ulbg27k);
                frm.ResetStopwatch();
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (chk2 != true)
            {
                chk2 = true;
                button7.BackColor = Color.Green;
                frm.Show();
            }
            else
            {
                chk2 = false;
                button7.BackColor = dlg13.Color;
                button7.BackColor = Settings1.Default.bgd2ol;
                frm.Hide();
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = Process.GetProcessesByName("destiny2")[0];
                int processId = process.Id;
                IntPtr processHandle = Process.GetProcessById(processId).Handle;

                if (chk1 != true)
                {
                    chk1 = true;
                    button8.BackColor = Color.Red;
                    NtSuspendProcess(processHandle);
                }
                else
                {
                    chk1 = false;
                    button8.BackColor = dlg13.Color;
                    button8.BackColor = Settings1.Default.bggp;
                    NtResumeProcess(processHandle);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("D2 is not opened");
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (chk != true)
            {
                chk = true;
                frm.SetLabel1Color(Color.Red);
                button9.BackColor = Color.Red;
                frm.StartStopwatch();
                INetFwPolicy2 instance1 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                foreach (INetFwRule rule in instance1.Rules)
                {
                    if (rule.Name.IndexOf("Destiny2PvP-In") != -1 || rule.Name.IndexOf("Destiny2PvP-Out") != -1)
                        return;
                }
                INetFwRule instance2 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                instance2.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                instance2.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                instance2.Enabled = true;
                instance2.InterfaceTypes = "All";
                instance2.Protocol = 6;
                instance2.RemotePorts = "27000-27200";
                instance2.Name = "Destiny2PvP-In-TCP";

                INetFwRule instance3 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                instance3.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                instance3.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                instance3.Enabled = true;
                instance3.InterfaceTypes = "All";
                instance3.Protocol = 17;
                instance3.RemotePorts = "27000-27200";
                instance3.Name = "Destiny2PvP-In-UDP";

                INetFwRule instance4 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                instance4.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                instance4.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                instance4.Enabled = true;
                instance4.InterfaceTypes = "All";
                instance4.Protocol = 6;
                instance4.RemotePorts = "27000-27200";
                instance4.Name = "Destiny2PvP-Out-TCP";

                INetFwRule instance5 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                instance5.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                instance5.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                instance5.Enabled = true;
                instance5.InterfaceTypes = "All";
                instance5.Protocol = 17;
                instance5.RemotePorts = "27000-27200";
                instance5.Name = "Destiny2PvP-Out-UDP";

                instance1.Rules.Add(instance2);
                instance1.Rules.Add(instance3);
                instance1.Rules.Add(instance4);
                instance1.Rules.Add(instance5);
            }
            else
            {
                foreach (INetFwRule rule in ((INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"))).Rules)
                {
                    if (rule.Name.IndexOf("Destiny2PvP-In") != -1 || rule.Name.IndexOf("Destiny2PvP-Out") != -1)
                    {
                        chk = false;
                        button9.BackColor = dlg17.Color;
                        button9.BackColor = Settings1.Default.bgpvp;
                        frm.SetLabel1Color(dlg17.Color);
                        frm.SetLabel1Color(Settings1.Default.bgpvp);
                        frm.ResetStopwatch();
                        ((INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"))).Rules.Remove(rule.Name);
                    }
                }
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            client.KillCnnsByFilterId(client.Filters.Find(x => x.Name == "30k").Id);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "Destiny 2");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                button11.BackColor = Color.Red;
                client.UpdateRule(rule);
                frm.SetLabel2Color(Color.Red);
                frm.StartStopwatch();
            }
            else
            {
                rule.IsEnabled = false;
                button11.BackColor = dlg21.Color;
                button11.BackColor = Settings1.Default.bglfg;
                client.UpdateRule(rule);
                frm.SetLabel2Color(dlg21.Color);
                frm.SetLabel2Color(Settings1.Default.bglfg);
                frm.ResetStopwatch();
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            if (chk3 != true)
            {
                chk3 = true;
                frm.SetLabel3Color(Color.Red);
                button12.BackColor = Color.Red;
                frm.StartStopwatch();
                INetFwPolicy2 instance1 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                foreach (INetFwRule rule in instance1.Rules)
                {
                    if (rule.Name.IndexOf("Destiny2PvE-In") != -1 || rule.Name.IndexOf("Destiny2PvE-Out") != -1)
                        return;
                }
                INetFwRule instance2 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                instance2.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                instance2.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                instance2.Enabled = true;
                instance2.InterfaceTypes = "All";
                instance2.Protocol = 6;
                instance2.RemotePorts = "3074";
                instance2.Name = "Destiny2PvE-In-TCP";

                INetFwRule instance3 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                instance3.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                instance3.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                instance3.Enabled = true;
                instance3.InterfaceTypes = "All";
                instance3.Protocol = 17;
                instance3.RemotePorts = "3074";
                instance3.Name = "Destiny2PvE-In-UDP";

                INetFwRule instance4 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                instance4.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                instance4.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                instance4.Enabled = true;
                instance4.InterfaceTypes = "All";
                instance4.Protocol = 6;
                instance4.RemotePorts = "3074";
                instance4.Name = "Destiny2PvE-Out-TCP";

                INetFwRule instance5 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                instance5.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                instance5.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                instance5.Enabled = true;
                instance5.InterfaceTypes = "All";
                instance5.Protocol = 17;
                instance5.RemotePorts = "3074";
                instance5.Name = "Destiny2PvE-Out-UDP";

                instance1.Rules.Add(instance2);
                instance1.Rules.Add(instance3);
                instance1.Rules.Add(instance4);
                instance1.Rules.Add(instance5);
            }
            else
            {
                foreach (INetFwRule rule in ((INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"))).Rules)
                {
                    if (rule.Name.IndexOf("Destiny2PvE-In") != -1 || rule.Name.IndexOf("Destiny2PvE-Out") != -1)
                    {
                        chk3 = false;
                        button12.BackColor = dlg23.Color;
                        button12.BackColor = Settings1.Default.bghpved;
                        frm.SetLabel3Color(dlg23.Color);
                        frm.SetLabel3Color(Settings1.Default.bghpved);
                        frm.ResetStopwatch();
                        ((INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"))).Rules.Remove(rule.Name);
                    }
                }
            }
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "30k");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                button13.BackColor = Color.Red;
                client.UpdateRule(rule);
                frm.SetLabel4Color(Color.Red);
                frm.StartStopwatch();
            }
            else
            {
                rule.IsEnabled = false;
                button13.BackColor = dlg25.Color;
                button13.BackColor = Settings1.Default.bg30k;
                client.UpdateRule(rule);
                frm.SetLabel4Color(dlg25.Color);
                frm.SetLabel4Color(Settings1.Default.bg30k);
                frm.ResetStopwatch();
            }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            frm1.Show();
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                int mousex = MousePosition.X;
                int mousey = MousePosition.Y;
                this.SetDesktopLocation(mousex, mousey);
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        public void ForegroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                button1.ForeColor = dlg.Color;
                Settings1.Default.dlfg3074 = dlg.Color;
                Settings1.Default.Save();
            }
        }

        public void BackgroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dlg1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = dlg1.Color;
                Settings1.Default.dlbg3074 = dlg1.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dlg2.ShowDialog() == DialogResult.OK)
            {
                button2.ForeColor = dlg2.Color;
                Settings1.Default.ulfg3074 = dlg2.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dlg3.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = dlg3.Color;
                Settings1.Default.ulbg3074 = dlg3.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                button3.ForeColor = dlg4.Color;
                Settings1.Default.dlfg7500 = dlg4.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dlg5.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = dlg5.Color;
                Settings1.Default.dlbg7500 = dlg5.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (dlg6.ShowDialog() == DialogResult.OK)
            {
                button4.ForeColor = dlg6.Color;
                Settings1.Default.ulfg7500 = dlg6.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (dlg7.ShowDialog() == DialogResult.OK)
            {
                button4.BackColor = dlg7.Color;
                Settings1.Default.ulbg7500 = dlg7.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (dlg8.ShowDialog() == DialogResult.OK)
            {
                button5.ForeColor = dlg8.Color;
                Settings1.Default.dlfg27k = dlg8.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (dlg9.ShowDialog() == DialogResult.OK)
            {
                button5.BackColor = dlg9.Color;
                Settings1.Default.dlbg27k = dlg9.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (dlg10.ShowDialog() == DialogResult.OK)
            {
                button6.ForeColor = dlg10.Color;
                Settings1.Default.ulfg27k = dlg10.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (dlg11.ShowDialog() == DialogResult.OK)
            {
                button6.BackColor = dlg11.Color;
                Settings1.Default.ulbg27k = dlg11.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (dlg12.ShowDialog() == DialogResult.OK)
            {
                button7.ForeColor = dlg12.Color;
                Settings1.Default.fgd2ol = dlg12.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (dlg13.ShowDialog() == DialogResult.OK)
            {
                button7.BackColor = dlg13.Color;
                Settings1.Default.bgd2ol = dlg13.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (dlg14.ShowDialog() == DialogResult.OK)
            {
                button8.ForeColor = dlg14.Color;
                Settings1.Default.fggp = dlg14.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (dlg15.ShowDialog() == DialogResult.OK)
            {
                button8.BackColor = dlg15.Color;
                Settings1.Default.bggp = dlg15.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (dlg16.ShowDialog() == DialogResult.OK)
            {
                button9.ForeColor = dlg16.Color;
                Settings1.Default.fgpvp = dlg16.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (dlg17.ShowDialog() == DialogResult.OK)
            {
                button9.BackColor = dlg17.Color;
                Settings1.Default.bgpvp = dlg17.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (dlg19.ShowDialog() == DialogResult.OK)
            {
                button10.ForeColor = dlg19.Color;
                Settings1.Default.fg30kkc = dlg19.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (dlg20.ShowDialog() == DialogResult.OK)
            {
                button10.BackColor = dlg20.Color;
                Settings1.Default.bg30kkc = dlg20.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (dlg20.ShowDialog() == DialogResult.OK)
            {
                button11.ForeColor = dlg20.Color;
                Settings1.Default.fglfg = dlg20.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (dlg21.ShowDialog() == DialogResult.OK)
            {
                button11.BackColor = dlg21.Color;
                Settings1.Default.bglfg = dlg21.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (dlg22.ShowDialog() == DialogResult.OK)
            {
                button12.ForeColor = dlg22.Color;
                Settings1.Default.fghpved = dlg22.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (dlg23.ShowDialog() == DialogResult.OK)
            {
                button12.BackColor = dlg23.Color;
                Settings1.Default.bghpved = dlg23.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (dlg24.ShowDialog() == DialogResult.OK)
            {
                button13.ForeColor = dlg24.Color;
                Settings1.Default.fg30k = dlg24.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (dlg25.ShowDialog() == DialogResult.OK)
            {
                button13.BackColor = dlg25.Color;
                Settings1.Default.bg30k = dlg25.Color;
                Settings1.Default.Save();
            }
        }

        public void RegisterButtonHotkey(Button button, ModKeys modKeys, Keys key, bool isEnabled)
        {
            HotkeyManager.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                if (args.Modifier == modKeys && args.Key == key && isEnabled)
                {
                    button.PerformClick();
                }
            };
            hotkeyManager.RegisterHotKey(modKeys, key);
        }
    }
}