using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canine_RMS_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.Bounds.Height;
            int y = Screen.PrimaryScreen.Bounds.Width;
            this.Height = x - 40;
            this.Width = y;
            this.Left = 0;
            this.Top = 0;
        }

        private void btnRep_Click(object sender, EventArgs e)
        {
            MnuRep rep = new MnuRep();
            rep.TopLevel = false;
            panel3.Controls.Add(rep);
            rep.BringToFront();
            rep.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMntn_Click(object sender, EventArgs e)
        {
            MnuMaintenance rep = new MnuMaintenance();
            rep.TopLevel = false;
            panel3.Controls.Add(rep);
            rep.Loader();
            rep.BringToFront();
            rep.Show();
        }
    }
}
