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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mini_Games
{
    public partial class Form1 : Form
    {
        SqlConnection con = new database().GetConnection();
        private string savedUsername;
        private string savedPassword;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            string username = usernametextBox.Text;
            string password = passwordtextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Details where User_Name=@User_Name AND Password=@Password", con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@User_Name", username);
                cmd.Parameters.AddWithValue("@Password", password);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    selectgame sc = new selectgame();
                    sc.Show();
                    Hide();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Invalid User Name Or Password");
                    usernametextBox.Clear();
                    passwordtextBox.Clear();
                    usernametextBox.Focus();
                    con.Close();
                }
            }

        }

        private void usernametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            usernametextBox.Clear();
            passwordtextBox.Clear();

            usernametextBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 w1 = new Form2();
            w1.Show();
            Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username1 = usernametextBox.Text;
            string password1 = passwordtextBox.Text;


            try
            {
                if (string.IsNullOrEmpty(username1) || string.IsNullOrEmpty(password1))
                {
                    MessageBox.Show("Please enter a username and password.");
                    return;
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Details where User_Name=@User_Name AND Password=@Password", con);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@User_Name", username1);
                    cmd.Parameters.AddWithValue("@Password", password1);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        string qry = "Delete from Details  where User_Name=@User_Name AND Password=@Password";
                        SqlCommand cmd1 = new SqlCommand(qry, con);
                        cmd1.Parameters.AddWithValue("@User_Name", username1);
                        cmd1.Parameters.AddWithValue("@Password", password1);
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Account Delete Completed");
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name Or Password");
                        usernametextBox.Clear();
                        passwordtextBox.Clear();
                        usernametextBox.Focus();
                        con.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}

