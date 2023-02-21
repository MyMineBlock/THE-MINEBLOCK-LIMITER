using NLMMB.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLLM;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace NLMMB
{
    public partial class FormUtility : Form
    {
        readonly Settings1 settings = new Settings1();

        public FormUtility()
        {
            InitializeComponent();
        }

        private void FormUtility_Load(object sender, EventArgs e)
        {
            GetSettings();
            TopMost = true;
        }

        private void GetSettings()
        {
            textBox1.Text = settings.dlbps3074.ToString();
            textBox2.Text = settings.ulbps3074.ToString();
            textBox3.Text = settings.dlbps7500.ToString();
            textBox4.Text = settings.ulbps7500.ToString();
            textBox5.Text = settings.dlbps27k.ToString();
            textBox6.Text = settings.ulbps27k.ToString();
            textBox7.Text = settings.bpslfg.ToString();
            textBox33.Text = settings.bps30k.ToString();
            textBox8.Text = settings.AppPath;

            textBox9.Text = settings.modkeydl3074.ToString();
            textBox10.Text = settings.modkeyul3074.ToString();
            textBox11.Text = settings.modkeydl7500.ToString();
            textBox12.Text = settings.modkeyul7500.ToString();
            textBox13.Text = settings.modkeydl27k.ToString();
            textBox14.Text = settings.modkeyul27k.ToString();
            textBox15.Text = settings.modkeylfg.ToString();
            textBox16.Text = settings.modkey30kl.ToString();
            textBox17.Text = settings.modkey30kkc.ToString();
            textBox18.Text = settings.modkeygp.ToString();
            textBox19.Text = settings.modkeypvel.ToString();
            textBox20.Text = settings.modkeypvpl.ToString();

            textBox21.Text = settings.keydl3074.ToString();
            textBox22.Text = settings.keyul3074.ToString();
            textBox23.Text = settings.keydl7500.ToString();
            textBox24.Text = settings.keyul7500.ToString();
            textBox25.Text = settings.keydl27k.ToString();
            textBox26.Text = settings.keyul27k.ToString();
            textBox27.Text = settings.keylfg.ToString();
            textBox28.Text = settings.key30kl.ToString();
            textBox29.Text = settings.key30kkc.ToString();
            textBox30.Text = settings.keygp.ToString();
            textBox31.Text = settings.keypvel.ToString();
            textBox32.Text = settings.keypvpl.ToString();

            if (settings.hotkeydl3074 == true)
            {
                checkBox1.Checked = true;
            }

            if (settings.hotkeyul3074 == true)
            {
                checkBox2.Checked = true;
            }

            if (settings.hotkeydl7500 == true)
            {
                checkBox3.Checked = true;
            }

            if (settings.hotkeyul7500 == true)
            {
                checkBox4.Checked = true;
            }

            if (settings.hotkeydl27k == true)
            {
                checkBox5.Checked = true;
            }

            if (settings.hotkeyul27k == true)
            {
                checkBox6.Checked = true;
            }

            if (settings.hotkeylfg == true)
            {
                checkBox7.Checked = true;
            }

            if (settings.hotkey30kl == true)
            {
                checkBox8.Checked = true;
            }

            if (settings.hotkey30kkc == true)
            {
                checkBox9.Checked = true;
            }

            if (settings.hotkeygp == true)
            {
                checkBox10.Checked = true;
            }

            if (settings.hotkeypvel == true)
            {
                checkBox11.Checked = true;
            }

            if (settings.hotkeypvpl == true)
            {
                checkBox12.Checked = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Settings1.Default.dlbps3074 = uint.Parse(textBox1.Text);
                Settings1.Default.ulbps3074 = uint.Parse(textBox2.Text);
                Settings1.Default.dlbps7500 = uint.Parse(textBox3.Text);
                Settings1.Default.ulbps7500 = uint.Parse(textBox4.Text);
                Settings1.Default.dlbps27k = uint.Parse(textBox5.Text);
                Settings1.Default.ulbps27k = uint.Parse(textBox6.Text);
                Settings1.Default.bpslfg = uint.Parse(textBox7.Text);
                Settings1.Default.bps30k = uint.Parse(textBox33.Text);
                Settings1.Default.AppPath = textBox8.Text;

                Settings1.Default.modkeydl3074 = (ModKeys)Enum.Parse(typeof(ModKeys), textBox9.Text);
                Settings1.Default.modkeyul3074 = (ModKeys)Enum.Parse(typeof(ModKeys), textBox10.Text);
                Settings1.Default.modkeydl7500 = (ModKeys)Enum.Parse(typeof(ModKeys), textBox11.Text);
                Settings1.Default.modkeyul7500 = (ModKeys)Enum.Parse(typeof(ModKeys), textBox12.Text);
                Settings1.Default.modkeydl27k = (ModKeys)Enum.Parse(typeof(ModKeys), textBox13.Text);
                Settings1.Default.modkeyul27k = (ModKeys)Enum.Parse(typeof(ModKeys), textBox14.Text);
                Settings1.Default.modkeylfg = (ModKeys)Enum.Parse(typeof(ModKeys), textBox15.Text);
                Settings1.Default.modkey30kl = (ModKeys)Enum.Parse(typeof(ModKeys), textBox16.Text);
                Settings1.Default.modkey30kkc = (ModKeys)Enum.Parse(typeof(ModKeys), textBox17.Text);
                Settings1.Default.modkeygp = (ModKeys)Enum.Parse(typeof(ModKeys), textBox18.Text);
                Settings1.Default.modkeypvel = (ModKeys)Enum.Parse(typeof(ModKeys), textBox19.Text);
                Settings1.Default.modkeypvpl = (ModKeys)Enum.Parse(typeof(ModKeys), textBox20.Text);

                Settings1.Default.keydl3074 = (Keys)Enum.Parse(typeof(Keys), textBox21.Text);
                Settings1.Default.keyul3074 = (Keys)Enum.Parse(typeof(Keys), textBox22.Text);
                Settings1.Default.keydl7500 = (Keys)Enum.Parse(typeof(Keys), textBox23.Text);
                Settings1.Default.keyul7500 = (Keys)Enum.Parse(typeof(Keys), textBox24.Text);
                Settings1.Default.keydl27k = (Keys)Enum.Parse(typeof(Keys), textBox25.Text);
                Settings1.Default.keyul27k = (Keys)Enum.Parse(typeof(Keys), textBox26.Text);
                Settings1.Default.keylfg = (Keys)Enum.Parse(typeof(Keys), textBox27.Text);
                Settings1.Default.key30kl = (Keys)Enum.Parse(typeof(Keys), textBox28.Text);
                Settings1.Default.key30kkc = (Keys)Enum.Parse(typeof(Keys), textBox29.Text);
                Settings1.Default.keygp = (Keys)Enum.Parse(typeof(Keys), textBox30.Text);
                Settings1.Default.keypvel = (Keys)Enum.Parse(typeof(Keys), textBox31.Text);
                Settings1.Default.keypvpl = (Keys)Enum.Parse(typeof(Keys), textBox32.Text);

                if (checkBox1.Checked)
                {
                    Settings1.Default.hotkeydl3074 = true;
                }
                else
                {
                    Settings1.Default.hotkeydl3074 = false;
                }

                if (checkBox2.Checked)
                {
                    Settings1.Default.hotkeyul3074 = true;
                }
                else
                {
                    Settings1.Default.hotkeyul3074 = false;
                }

                if (checkBox3.Checked)
                {
                    Settings1.Default.hotkeydl7500 = true;
                }
                else
                {
                    Settings1.Default.hotkeydl7500 = false;
                }

                if (checkBox4.Checked)
                {
                    Settings1.Default.hotkeyul7500 = true;
                }
                else
                {
                    Settings1.Default.hotkeyul7500 = false;
                }

                if (checkBox5.Checked)
                {
                    Settings1.Default.hotkeydl27k = true;
                }
                else
                {
                    Settings1.Default.hotkeydl27k = false;
                }

                if (checkBox6.Checked)
                {
                    Settings1.Default.hotkeyul27k = true;
                }
                else
                {
                    Settings1.Default.hotkeyul27k = false;
                }

                if (checkBox7.Checked)
                {
                    Settings1.Default.hotkeylfg = true;
                }
                else
                {
                    Settings1.Default.hotkeylfg = false;
                }

                if (checkBox8.Checked)
                {
                    Settings1.Default.hotkey30kl = true;
                }
                else
                {
                    Settings1.Default.hotkey30kl = false;
                }

                if (checkBox9.Checked)
                {
                    Settings1.Default.hotkey30kkc = true;
                }
                else
                {
                    Settings1.Default.hotkey30kkc = false;
                }

                if (checkBox10.Checked)
                {
                    Settings1.Default.hotkeygp = true;
                }
                else
                {
                    Settings1.Default.hotkeygp = false;
                }

                if (checkBox11.Checked)
                {
                    Settings1.Default.hotkeypvel = true;
                }
                else
                {
                    Settings1.Default.hotkeypvel = false;
                }

                if (checkBox12.Checked)
                {
                    Settings1.Default.hotkeypvpl = true;
                }
                else
                {
                    Settings1.Default.hotkeypvpl = false;
                }

                Settings1.Default.Save();
                MessageBox.Show("Restart the application");
            }
            catch (Exception)
            {
                MessageBox.Show("Some type of syntax error");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I will be working on many things for many months!");
        }
    }
}