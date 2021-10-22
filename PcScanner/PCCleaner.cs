using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace PcScanner
{
    public partial class PCCleaner : Form
    {
        private bool ALT_F4 = false;

        public PCCleaner()
        {
            MessageBox.Show("Make sure you save your work before you continue!", "Warning", MessageBoxButtons.OK);
            InitializeComponent();
        }

        public void Form1_FormClosed(object sender, FormClosingEventArgs e)
        {
            if (ALT_F4)
            {
                label1.Text = "Alt-F4 still calls the same event as exiting\nnormally stupid idiot stupid!";
            }
            e.Cancel = true;
            PCMini pc = new PCMini();
            pc.Show();
        }
        public void PCCleaner_KeyDown(object sender, KeyEventArgs e)
        {
            ALT_F4 = (e.KeyCode.Equals(Keys.F4) && e.Alt == true);
        }

        private void PCCleaner_Load(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\bfb stupid idiot stupid.wav";
            sp.PlayLooping();
        }
    }
}
