using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using c_sharp_webscraper.Models;

namespace c_sharp_webscraper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static async Task<string> CallUrl(string fullUrl)
        {
            // Create Http client

            // Force connection to use TLS 1.3 so that HTTPS handshake can complete

            // Clear headers, should you add your own

            // Await the response
        }

        public IActionResult Index()
        {
            string url = "https://en.wikipedia.org/wiki/List_of_programmers";
            return View();
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
