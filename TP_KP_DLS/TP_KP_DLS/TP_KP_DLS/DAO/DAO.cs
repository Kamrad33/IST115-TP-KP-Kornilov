using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using TP_KP_DLS.Models;

namespace TP_KP_DLS.DAO
{
    public class DAO
    {
        string myConnectionString = @"Data Source=sergvlad\SQLEXPRESS;Initial Catalog=DLS_Server;Integrated Security=True;";
        public SqlConnection Connection { get; set; }
        public void Connect()
        {
            Log.For(this).Info("Connection success");
            Connection = new SqlConnection(myConnectionString);
            Connection.Open();
        }


        public void Disconnect()
        {
            Log.For(this).Info("Connection close");
            Connection.Close();
        }
    }
}