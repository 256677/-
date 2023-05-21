using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lysl
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            populate();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\25699\Documents\slckgl.mdf;Integrated Security=True;Connect Timeout=30");

        private void Reset()
        {
            Uname.Text = "";
            Phone.Text = "";
            Add.Text = "";
            Pwd.Text = "";
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from UserTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Uname.Text == "" || Phone.Text == "" || Add.Text == "" || Pwd.Text == "" )
            {
                MessageBox.Show("信息缺失！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into [UserTb1] values('" + Uname.Text + "','" + Phone.Text + "','" + Add.Text + "','" + Pwd.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("用户信息保存成功！");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int key = 0;
        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Uname.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            Phone.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            Add.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            Pwd.Text = UserDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (Uname.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("信息缺失！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from [UserTb1] where Uid = " + key + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("用户信息删除成功！");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Uname.Text == "" || Phone.Text == "" || Add.Text == "" || Pwd.Text == "")
            {
                MessageBox.Show("信息缺失！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update [UserTb1] set UName='" + Uname.Text + "',UPhone='" + Phone.Text + "',UAdd='" + Add.Text + "',UPwd='" + Pwd.Text + "' where Uid=" + key + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("用户信息编辑完成！");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            zhuye zhuye = new zhuye();
            zhuye.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            zhgl zhgl  =new zhgl();
            zhgl.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login zhuye = new Login();
            zhuye.Show();
            this.Hide();
        }
    }
}
