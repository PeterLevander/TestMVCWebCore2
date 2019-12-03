using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestMVCWebCore.Models;

namespace TestMVCWebCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration )
        {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var model = configuration["Greeting"];
            ViewData["Message"] = "Your application description page.";

            return View("About", model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
