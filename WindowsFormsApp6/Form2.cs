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
using System.Data.Sql;
namespace WindowsFormsApp6
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignIn s2 = new SignIn();
            s2.Show();
            this.Hide();
        }
        private int GenerateUniqueId()
        {
            // Generate a unique ID based on the current timestamp (you can modify this according to your requirements)
            return (int)DateTime.Now.Ticks;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            // Get the input values from the TextBoxes
            string name = txt_name.Text;
            string username = txt_username.Text;
            string password = txt_password.Text;
            string email = txt_email.Text;
            string cnic = txt_email.Text;

            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(cnic))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the event handler
            }

            // Generate a unique ID for the user (you can modify this according to your requirements)
            int id = GenerateUniqueId();

            // Insert the user data into the database
            string connectionString = "Data Source=DESKTOP-DVPJ8C1\\SQLEXPRESS;Initial Catalog=Ticket Management System;Integrated Security=True"; // Replace with your actual connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO adminsignup (id, name, username, password, email, cnic) VALUES (@id, @name, @username, @password, @email, @cnic)";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", username);
                    command.Parameters.AddWithValue("@username", name);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@cnic", cnic);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Signup successful!");

            // Clear the TextBoxes
            txt_name.Clear();
            txt_username.Clear();
            txt_password.Clear();
            txt_email.Clear();
            txt_cnic.Clear();
        }
    }
}
