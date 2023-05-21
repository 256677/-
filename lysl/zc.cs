using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lysl
{
    public partial class zc : Form
    {
        public zc()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\25699\Documents\slckgl.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = false;
            if (Uname.Text.Trim() == "" || pwd.Text.Trim() == "" || Pwd1.Text.Trim() == ""||Phone.Text == "" || Add.Text == "")
            {
                MessageBox.Show("信息缺失");
            }
            else
            {
                if (pwd.Text.Trim() != Pwd1.Text.Trim())
                {
                    MessageBox.Show("两次密码输入不一致，请重新输入！");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("", Con);
                    string sql = "select UName from UserTb1 where UName='" + Uname.Text.Trim() + "'";
                    cmd.CommandText = sql;
                    if (cmd.ExecuteScalar() == null)
                    {
                        sql = "insert into [UserTb1] values('" + Uname.Text + "','" + Phone.Text + "','" + Add.Text + "','" + pwd.Text + "')";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("用户注册成功");
                    }
                    else
                    {
                        MessageBox.Show("该用户已存在");
                        Con.Close();
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login zhuye = new Login();
            zhuye.Show();
            this.Hide();
        }

        private void zc_Load(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
