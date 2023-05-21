using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lysl
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\25699\Documents\slckgl.mdf;Integrated Security=True;Connect Timeout=30");
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static string UserName = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda= new SqlDataAdapter("select count(*) from UserTb1 where UName='"+Uname.Text+"' and UPwd='"+Upwd.Text+"'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString()=="1")
            {
                UserName = Uname.Text;
                gouw zhuye = new gouw();
                zhuye.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
            }
            Con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            zc zc = new zc();
            zc.Show();
            this.Hide();
        }
    }
}
