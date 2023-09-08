using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace _5413__ASP.NET.DAL
{
    public class DAL
    {
        private string connString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=blog;Integrated Security=True;";

        public string getconnString()
        {
            return connString;
        }

        public bool crud(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            conn.Close();
            return true;
        }//-----------------------------------------------------------------------------

        public int countRows(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = conn;
            object result = cmd.ExecuteScalar();
            int rowCount = Convert.ToInt32(result);

            conn.Close();
            return rowCount;
        }//---------------------------------------------------------------------------------------

        public DataSet obterDs(string sqlSelect)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            conn.Close();
            return ds;
        }


    }
}