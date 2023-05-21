using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lysl
{
    public partial class jz : Form
    {
        public jz()
        {
            InitializeComponent();
        }

        int startpos=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 1;
            jdt.Value = startpos;
            PercentageLbl.Text = startpos + "%";
            if(jdt.Value==100)
            {
                jdt.Value = 0;
                timer1.Stop();
                Login log=new Login();
                log.Show();
                this.Hide();
            }
        }

        private void jz_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void jdt_Click(object sender, EventArgs e)
        {

        }
    }
}
