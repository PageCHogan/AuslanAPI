using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuslanAPI.Models;
using AuslanAPI.Models.HttpResponses;
using AuslanAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuslanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService service = new UserService();

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            HttpResponseData response = new HttpResponseData();

            List<UserDataModel> users = service.GetUsers(id);

            if(users.Count > 0)
            {
                response.Request = id;
                response.Data = users[0];
                response.Message = "Successfully did the thing.";
            }

            return JsonConvert.SerializeObject(response);
            //return JsonConvert.SerializeObject(service.GetUsers(id));
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
