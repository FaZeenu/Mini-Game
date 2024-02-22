using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Games
{
   class database
    {
        public SqlConnection GetConnection()
        {
            
            string ConnectionString = "Data Source=DARK_PHOENIX\\SQLEXPRESS;Initial Catalog=miniGame;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }
        
        public DataSet Getdata(string qry)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(qry,con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }
        
        public void setData(String qry)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = qry;
            cmd.ExecuteNonQuery();
            con.Close();



        }

    }
}
