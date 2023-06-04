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

namespace WindowsFormsApp6
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            SignUp s1 = new SignUp();
            s1.Show();
            this.Hide();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "")
            {
                MessageBox.Show("Enter the username");
            }
            else if(txt_password.Text == "")
            {
                MessageBox.Show("Enter the password");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source = DESKTOP - DVPJ8C1\\SQLEXPRESS; Initial Catalog = Ticket Management System; Integrated Security = True");
                    SqlCommand cmd = new SqlCommand("select * from adminsignup where username = @username and password = @password", con);
                    cmd.Parameters.AddWithValue("@username", txt_username.Text);
                    cmd.Parameters.AddWithValue("@password", txt_password.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    if(dt.Rows.Count > 0)
                    {
                        MessageBox.Show("login successful");
                    }
                    else
                    {
                        MessageBox.Show("username or password is invalid");
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }
    }
}
