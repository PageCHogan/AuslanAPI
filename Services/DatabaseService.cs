using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace AuslanAPI.Services
{
    public class DatabaseService
    {
        public string CONNECTION_STRING = "";

        public DatabaseService()
        {
            //TODO: Connection string not loading from config correctly
            //CONNECTION_STRING = ConfigurationManager.ConnectionStrings["auslanDB"].ConnectionString;

            CONNECTION_STRING = "Data Source=HOGAN-PC\\SQLEXPRESS;Initial Catalog=Auslan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            if (string.IsNullOrEmpty(CONNECTION_STRING))
            {
                throw new Exception("Fatal error: missing connecting string in web.config file");
            }
        }
    }
}
