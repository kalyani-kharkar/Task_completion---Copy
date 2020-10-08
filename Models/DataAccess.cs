using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Configuration;

namespace Task_completion.Models
{
    public class DataAccess
    {
        private SqlConnection con;
        public void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["t"].ToString();
            con = new SqlConnection(constr);
        }
        public void UserLoginDetails(UserLogin userLogin)
        {
            connection();
            int newProdID;
            string Sqlquery = "select UserName,Password from tblUsers where UserName=@UserName and Password=@Password ";
           // con.Open();
            SqlCommand sqlCommand = new SqlCommand(Sqlquery, con);
            sqlCommand.Parameters.AddWithValue("@UserName", userLogin.UserName);
            sqlCommand.Parameters.AddWithValue("@Password", userLogin.Password);
            sqlCommand.ExecuteNonQuery();
            //try
            //{
            //    con.Open();
            //    newProdID = (Int32)sqlCommand.ExecuteNonQuery();
            //    return (int)newProdID;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
           
        }
       
    }
}