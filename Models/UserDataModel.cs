using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuslanAPI.Models
{
    public class UserDataModel : BaseDataModel
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }

        public UserDataModel()
        {
            Username = null;
            Firstname = null;
            Lastname = null;
            Password = null;
        }
    }
}
