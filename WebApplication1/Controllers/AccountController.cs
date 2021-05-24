using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View("Users");
        }
       
        public ActionResult Users()
        {
            return View();
        }

    }
}