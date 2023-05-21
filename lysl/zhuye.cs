using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lysl
{
    public partial class zhuye : Form
    {
        public zhuye()
        {
            InitializeComponent();
            populate();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\25699\Documents\slckgl.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from Sl1";
            SqlDataAdapter sda = new SqlDataAdapter(query,Con);
            SqlCommandBuilder builder=new SqlCommandBuilder(sda);
            var ds=new DataSet();
            sda.Fill(ds);
            SlDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Filter()
        {
            Con.Open();
            string query = "select * from Sl1 where Lx = '"+ CatCbsearchCb .SelectedItem.ToString()+ "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SlDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SabeBtn_Click(object sender, EventArgs e)
        {
            if(Fodder.Text==""||Origin.Text==""||Type.SelectedIndex==-1||Number.Text==""||Price.Text=="")
            {
                MessageBox.Show("信息缺失！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into [Sl1] values('" + Fodder.Text + "','" + Origin.Text + "','" + Type.SelectedItem.ToString() + "','" + Number.Text + "','" + Price.Text + "')";
                    SqlCommand cmd=new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("饲料信息保存成功！");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }    
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CatCbsearchCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate();
            CatCbsearchCb.SelectedIndex = -1;
        }
        private void Reset()
        {
            Fodder.Text = "";
            Origin.Text = "";
            Type.SelectedIndex = -1;
            Number.Text = "";
            Price.Text = "";
        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        int key=0;
        private void SlDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Fodder.Text = SlDGV.SelectedRows[0].Cells[1].Value.ToString();
            Origin.Text = SlDGV.SelectedRows[0].Cells[2].Value.ToString();
            Type.SelectedItem = SlDGV.SelectedRows[0].Cells[3].Value.ToString();
            Number.Text = SlDGV.SelectedRows[0].Cells[4].Value.ToString();
            Price.Text = SlDGV.SelectedRows[0].Cells[5].Value.ToString();
            if(Fodder.Text=="")
            {
                key=0;
            }
            else
            {
                key = Convert.ToInt32(SlDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("信息缺失！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Sl1 where Sid = " + key + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("饲料信息删除成功！");
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

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (Fodder.Text == "" || Origin.Text == "" || Type.SelectedIndex == -1 || Number.Text == "" || Price.Text == "")
            {
                MessageBox.Show("信息缺失！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Sl1 set SlName='"+Fodder.Text+ "',Cd='"+Origin.Text+ "',Lx ='"+Type.SelectedIndex+ "',Sl="+Number.Text+ ",Jg="+Price.Text+" where Sid="+key+"";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("饲料信息编辑完成！");
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login zhuye = new Login();
            zhuye.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void zhuye_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Users zhuye = new Users();
            zhuye.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            zhgl zhgl = new zhgl();
            zhgl.Show();
            this.Hide();
        }

        private void CatCbsearchCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
