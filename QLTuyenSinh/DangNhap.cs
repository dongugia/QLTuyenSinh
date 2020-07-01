using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTuyenSinh
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 10;
            label1.Left += 1;
            if (label1.Left > this.Width - label1.Width || label1.Width <= 0) i = -1;

        }
        private void TruyCap(string truyvan)
        {
            SqlConnection con = null;
            SqlDataAdapter daTbl = null;
            DataTable dtTbl = null;

            string ketnoi = @"Data Source=DK0626-PC\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True";
            try
            {
                con = new SqlConnection(ketnoi);
                daTbl = new SqlDataAdapter(truyvan, con);
                dtTbl = new DataTable();
                dtTbl.Clear();
                daTbl.Fill(dtTbl);

                dataGridView1.DataSource = dtTbl;
                daTbl.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            TruyCap("select * from Users");

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (textBox1.Text == dataGridView1.Rows[i].Cells[1].Value.ToString() && dataGridView1.Rows[i].Cells[2].Value.ToString() == textBox2.Text
                    && dataGridView1.Rows[i].Cells[3].Value.ToString() == "0")
                {
                    textBox1.Text = textBox2.Text = "";
                    MessageBox.Show("Bạn đã đăng nhập thành công với tư cách là quản trị viên!");
                }
                else if (textBox1.Text == dataGridView1.Rows[i].Cells[1].Value.ToString() && dataGridView1.Rows[i].Cells[2].Value.ToString() == textBox2.Text
                    && dataGridView1.Rows[i].Cells[3].Value.ToString() == "1")
                {
                    textBox1.Text = textBox2.Text = "";
                    MessageBox.Show("Bạn đã đăng nhập thành công với tư cách là nhân viên!");
                }
                else if(textBox1.Text != dataGridView1.Rows[i].Cells[1].Value.ToString() ^ dataGridView1.Rows[i].Cells[2].Value.ToString() != textBox2.Text)
                {
                    textBox1.Focus();
                    MessageBox.Show("Đăng nhập không thành công, \r\nXin kiểm tra lại!");
                }
            }
        }
    }
}
