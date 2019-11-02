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
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings["auslanDB"].ConnectionString;
            if (string.IsNullOrEmpty(CONNECTION_STRING))
            {
                throw new Exception("Fatal error: missing connecting string in web.config file");
            }
        }
    }
}
