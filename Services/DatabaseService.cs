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

            //CONNECTION_STRING = "Data Source=HOGAN-PC\\SQLEXPRESS;Initial Catalog=Auslan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            CONNECTION_STRING = "Server=sql201.epizy.com;Database=epiz_24855319_Auslan;User Id=epiz_24855319;Password=8L2bITgOIx;";

            CONNECTION_STRING = "Data Source=185.27.134.10,1433;Initial Catalog = epiz_24855319_Auslan; User ID = epiz_24855319; Password = 8L2bITgOIx;";

            if (string.IsNullOrEmpty(CONNECTION_STRING))
            {
                throw new Exception("Fatal error: missing connecting string in web.config file");
            }
        }
    }
}
