﻿using DigitalData.SqlRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DigitalData.SqlRepository
{
    public class RepositoryBase : IRepositoryBase
    {
        public SqlConnection connection { get; set; }
        public string connectionstring = ConfigurationManager.ConnectionStrings["DigitalDataSqlDb"].ConnectionString;
        //public string connectionstring = ConfigurationManager.ConnectionStrings["CnnStr"].ConnectionString;

        public RepositoryBase()
        {
            //try
            //{
            //    this.Initialize();
            //    this.OpenConnection();
            //}
            //catch
            //{
            //    throw;
            //}
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public void Initialize()
        {
            this.connection = new SqlConnection(connectionstring);
            
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                //The two most common error numbers when connecting are as follows:                
                switch (ex.Number)
                {
                    case 0: //Cannot connect to server.                        
                        break;

                    case 1045: //Invalid user name and/or password.                        
                        break;
                }
                return false;
            }
        }
    }
}