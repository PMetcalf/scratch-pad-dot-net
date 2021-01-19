using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using c_sharp_webscraper.Models;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
            HttpClient client = new HttpClient();

            // Force connection to use TLS 1.3 so that HTTPS handshake can complete
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;

            // Clear headers, so bespoke headers can be added if requested
            client.DefaultRequestHeaders.Accept.Clear();

            // Await the response
            var response = client.GetStringAsync(fullUrl);
            return await response;
        }

        private List<string> ParseHtml(string html)
        {
            // Drop raw html links into Doc format
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            // Use linq to filter out the table of contents links we don't want 
            var programmerLinks = htmlDoc.DocumentNode.Descendants("li").
                Where(node => !node.GetAttributeValue("class", "").Contains("tocsection")).ToList();

            List<string> wikiLink = new List<string>();

            // Parse the link and construct / return the absolute url for the reader
            foreach (var link in programmerLinks)
            {
                if (link.FirstChild.Attributes.Count > 0)
                {
                    wikiLink.Add("https://en.wikipedia.org/" + link.FirstChild.Attributes[0].Value);
                }
            }

            return wikiLink;
        }

        public IActionResult Index()
        {
            string url = "https://en.wikipedia.org/wiki/List_of_programmers";

            var response = CallUrl(url).Result;

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
