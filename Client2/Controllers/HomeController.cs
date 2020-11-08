using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Client2.Models;
using Newtonsoft.Json;
using System.Text;

namespace Client2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profil()
        {
            byte[] sessionByte;
            HttpContext.Session.TryGetValue("UserInfo", out sessionByte);
            var userJson = Encoding.UTF8.GetString(sessionByte);
            var UserModel = JsonConvert.DeserializeObject(userJson);

            return View(UserModel);
        }

    }
}
