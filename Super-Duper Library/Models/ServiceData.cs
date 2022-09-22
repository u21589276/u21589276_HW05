using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;


namespace Super_Duper_Library.Models
{
    public class ServiceData
    {
        private String ConnectionString;
        SqlConnection myconnection = new SqlConnection("Data Source=cmsa\tew_sqlexpress;Initial Catalog=Library;Integrated Security=True");

        public ServiceData()
        {

        }



    }
}