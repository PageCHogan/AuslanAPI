using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuslanAPI.Models.HttpResponses
{
    public class BaseHttpResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        
        public BaseHttpResponse()
        {
            Status = StatusCodes.Status400BadRequest;
            Message = "Unable to retrieve data as requested.";
        }
    }
}