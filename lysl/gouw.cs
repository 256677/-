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
    public partial class gouw : Form
    {
        public gouw()
        {
            InitializeComponent();
            populate();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\25699\Documents\slckgl.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from Sl1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SlDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        int n = 0, SS = 0;
        private void UpdateSl()
        {
            int newnumber = stock - Convert.ToInt32(Number.Text);
            try
            {
                Con.Open();
                string query = "update Sl1 set Sl=" + newnumber + "where Sid=" + key + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("饲料信息编辑完成！");
                Con.Close();
                populate();
                //chong();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            
            if (Number.Text == "" || Convert.ToInt32(Number.Text) > stock)
            {
                MessageBox.Show("库存不足！");
            }else
            {
                int total = Convert.ToInt32(Price.Text) * Convert.ToInt32(Number.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dind);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = Sname.Text;
                newRow.Cells[2].Value = Price.Text;
                newRow.Cells[3].Value = Number.Text;
                newRow.Cells[4].Value=total;
                dind.Rows.Add(newRow);
                n++;
                UpdateSl();
                SS=SS+total;
                label3.Text = SS + "元";
            }
        }

        int key=0,stock=0;

        private void SlDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Sname.Text = SlDGV.SelectedRows[0].Cells[1].Value.ToString();
            //Number.Text = SlDGV.SelectedRows[0].Cells[4].Value.ToString();
            Price.Text = SlDGV.SelectedRows[0].Cells[5].Value.ToString();
            Number.Text = "";
            if (Sname.Text == "")
            {
                key = 0;
                stock = 0;
            }
            else
            {
                key = Convert.ToInt32(SlDGV.SelectedRows[0].Cells[0].Value.ToString());
                stock = Convert.ToInt32(SlDGV.SelectedRows[0].Cells[4].Value.ToString());
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void Print_Click(object sender, EventArgs e)
        {
            
            if (dind.Rows[0].Cells[0].Value==null)
            {
                MessageBox.Show("您未选择商品！");
            }
            else
            {
                
                try
                {
                    Con.Open();
                    string query = "insert into [SlTb1] values('" + label11.Text + "',"+SS+ ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("订单信息保存成功！");
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }
        int prodid, prodqty, prodprice, tottal, pos = 60;

        private void gouw_Load(object sender, EventArgs e)
        {
            label11.Text = Login.UserName;
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

        private void dind_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        string prodname;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("卢阳饲料厂", new Font("幼圆", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("编号 产品 价格 数量 总计", new Font("幼圆", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach (DataGridViewRow row in dind.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column3"].Value);
                prodname =""+row.Cells["Column7"].Value;
                prodprice= Convert.ToInt32(row.Cells["Column8"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column9"].Value);
                tottal = Convert.ToInt32(row.Cells["Column10"].Value);
                e.Graphics.DrawString("" + prodid, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + prodname,new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + prodqty, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos=pos+20;
            }
            e.Graphics.DrawString("订单总额：¥" + label3.Text, new Font("幼圆", 12, FontStyle.Bold), Brushes.Crimson, new Point(60, pos + 50));
            e.Graphics.DrawString("**********卢阳饲料厂**********" , new Font("幼圆", 10, FontStyle.Bold), Brushes.Crimson, new Point(40, pos + 85));
            dind.Rows.Clear();
            dind.Refresh();
            pos = 100;
            label3=new Label();
        }



        private void chong()
        {
            Sname.Text = "";
            Number.Text = "";
            Price.Text = "";
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            chong();
        }
    }
}
