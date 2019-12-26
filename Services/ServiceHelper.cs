using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AuslanAPI.Services
{
    public static class ServiceHelper
    {
        public static List<T> LoadJson<T>(string filename)
        {
            using StreamReader r = new StreamReader(filename);
            string json = r.ReadToEnd();
            List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
            return items;
        }
    }
}
