using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuslanAPI.Models.HttpResponses
{
    public class HttpResponseData : BaseHttpResponse
    {
        public object Data { get; set; }
        public object Request { get; set; }

        public HttpResponseData()
        {
            Data = null;
            Request = null;
        }
    }
}
