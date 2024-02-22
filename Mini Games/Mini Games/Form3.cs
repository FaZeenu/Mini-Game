using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Mini_Games
{
    public partial class Form3 : Form
    {
        SqlConnection con = new database().GetConnection();

        private string savedUsername;
        private string savedPassword;
        //  private SqlConnection con;

        public Form3()
        {
            InitializeComponent();
            // con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\zeena\\OneDrive\\Documents\\gamelogindata.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 w1 = new Form2();
            w1.Show();
            Hide();

        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                con.Open();
                string qry = "insert into Details  values(@User_Name,@Password)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@User_Name", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registration Completed");
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


