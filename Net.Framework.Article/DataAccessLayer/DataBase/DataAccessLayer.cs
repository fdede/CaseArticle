using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helper;

namespace DataAccessLayer.DataBase
{
    public class DataAccessLayer : GlobalTransactions
    {
        public SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        int ReturnValue;

        public DataAccessLayer()
        {
            con = new SqlConnection("data source=DESKTOP-GH25RPB\\SQLEXPRESS; initial catalog=CaseArticle; user id =sa; password = 123");
        }

        public int Run(SqlCommand cmd)
        {
            cmd.Connection = con;
            con.Open();
            TryIt(() =>
            {
                ReturnValue = cmd.ExecuteNonQuery();
            });
            con.Close();
            return ReturnValue;
        }

        public SqlDataReader GetData(SqlCommand cmd)
        {
            cmd.Connection = con;
            con.Open();
            TryIt(() =>
            {
                reader = cmd.ExecuteReader();
            });
            return reader;
        }

        public int RunInt(SqlCommand cmd)
        {
            cmd.Connection = con;
            con.Open();
            TryIt(() =>
            {
                ReturnValue = (int)cmd.ExecuteScalar();
            });
            con.Close();
            return ReturnValue;
        }

    }
}
