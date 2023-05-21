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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Upwd.Text == "password")
            {
                zhuye zhuye = new zhuye();
                zhuye.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("密码错误!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login zhuye = new Login();
            zhuye.Show();
            this.Hide();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
