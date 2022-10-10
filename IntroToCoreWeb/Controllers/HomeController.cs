using IntroToCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace IntroToCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _c;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IConfiguration config)
        {
            _logger = logger;
            _c = config;
        }

        public IActionResult Index()
        {
            string cn=_c.GetConnectionString("PubsCnString");
           

            string pname=System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            return Content(cn + " " + pname);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
