﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBookShop.Model
{
    class DB
    {
        private static DB instance;
        public static SqlConnection SqlConnection { get; set; }

        private DB()
        {
            SqlConnection = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=UBookShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection.Open();
        }

        public static DB getInstance()
        {
            if (instance == null)
            {
                instance = new DB();
            }
            return instance;
        }

        public static void Close()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }
    }
}
