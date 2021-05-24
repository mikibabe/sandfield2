using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {

        [System.Web.Http.Route("User/GetUserList")]
        public string GetUserList()
        {
            var d = UserService.GetUserList();
            return JsonConvert.SerializeObject(d);
        }

        [System.Web.Http.Route("User/GetUserById/{id}")]
        public string GetUserById(int id)
        {
            var d = UserService.GetUserById(id);
            return JsonConvert.SerializeObject(d);
        }

        [System.Web.Http.Route("User/GetUserAccessLevelById/{id}")]
        public string GetUserAccessLevelById(int id)
        {
            var d = UserService.GetUserAccessLevelById(id);
            return JsonConvert.SerializeObject(d);
        }

        [System.Web.Http.Route("User/EditUser")]
        public bool EditUser([FromBody]User user)
        {
           return UserService.EditUser(user);
        }

    }
}
