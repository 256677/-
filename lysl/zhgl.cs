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
    public partial class zhgl : Form
    {
        public zhgl()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\25699\Documents\slckgl.mdf;Integrated Security=True;Connect Timeout=30");
        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void zhgl_Load(object sender, EventArgs e)
        {
            Con.Open();

            SqlDataAdapter sda= new SqlDataAdapter("select sum(Sl) from Sl1",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            slsl.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(Amount) from SlTb1", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            xsje.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from UserTb1", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            yhrs.Text = dt2.Rows[0][0].ToString();

            Con.Close ();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            zhuye zhuye=new zhuye();
            zhuye.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Users zhuye = new Users();
            zhuye.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void slsl_Click(object sender, EventArgs e)
        {

        }
    }
}
