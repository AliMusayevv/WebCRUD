using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace WebCRUD
{
    public class Connection
    {
        public static string DS
        {
            get
            {
                return "Data Source=MARCELINE;Initial Catalog=LoginPage;Integrated Security = True";
            }


        }
        public static int Update(string test1, string test2, string test3, string test4, string test5,int id)

        {
            using (SqlConnection conn = new SqlConnection(Connection.DS))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("update WebCRUD set FIRSTNAME=@FIRSTNAME,LASTNAME=@LASTNAME,FATHERNAME=@FATHERNAME,EMAIL=@EMAIL,PHONE=@PHONE where ID=@ID ", conn);

                cmd.Parameters.AddWithValue("@FIRSTNAME", test1);
                cmd.Parameters.AddWithValue("@LASTNAME", test2);
                cmd.Parameters.AddWithValue("@FATHERNAME", test3);
                cmd.Parameters.AddWithValue("@EMAIL", test4);
                cmd.Parameters.AddWithValue("@PHONE", test5);
                cmd.Parameters.AddWithValue("@ID", id);



                int n = cmd.ExecuteNonQuery();

                conn.Close();
                return n;
            }
        }
        public static int Delete(int id)

        {
            using (SqlConnection conn = new SqlConnection(Connection.DS))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from WebCRUD where ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                int x = cmd.ExecuteNonQuery();

                conn.Close();
                return x;
            }

        }
    }
}