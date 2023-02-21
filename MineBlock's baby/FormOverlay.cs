using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace NLMMB
{
    public partial class FormOverlay : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public Stopwatch stopwatch = new Stopwatch();

        public Timer timer = new Timer();

        public FormOverlay()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.Manual;
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            Location = new Point(screenBounds.Width - Width, screenBounds.Height - Height);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            BackColor = Color.Wheat;
            TransparencyKey = Color.Wheat;
            TopMost = true;

            int initialStyle = GetWindowLong(Handle, -20);
            SetWindowLong(Handle, -20, initialStyle | 0x80000 | 0x20);
        }

        public void StartStopwatch()
        {
            timer.Interval = 1;
            timer.Tick += new EventHandler(Timer1_Tick);
            stopwatch.Start();
            timer.Start();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            label11.Text = elapsedTime.ToString(@"ss\.ff");
        }

        public void ResetStopwatch()
        {
            stopwatch.Stop();
            stopwatch.Reset();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            label11.Text = elapsedTime.ToString(@"ss\.ff");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = stopwatch.Elapsed;
            label11.Text = elapsedTime.ToString(@"ss\.ff");
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        public void SetLabel1Color(Color color)
        {
            label1.BackColor = color;
        }

        public void SetLabel2Color(Color color)
        {
            label2.BackColor = color;
        }

        public void SetLabel3Color(Color color)
        {
            label3.BackColor = color;
        }

        public void SetLabel4Color(Color color)
        {
            label4.BackColor = color;
        }

        public void SetLabel5Color(Color color)
        {
            label5.BackColor = color;
        }

        public void SetLabel6Color(Color color)
        {
            label6.BackColor = color;
        }

        public void SetLabel7Color(Color color)
        {
            label7.BackColor = color;
        }

        public void SetLabel8Color(Color color)
        {
            label8.BackColor = color;
        }

        public void SetLabel9Color(Color color)
        {
            label9.BackColor = color;
        }

        public void SetLabel10Color(Color color)
        {
            label10.BackColor = color;
        }
    }
}
