using c_sharp_webscraper.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net;
using PuppeteerSharp;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_webscraper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

        }

        /*
        public async Task<IActionResult> Index()
        {
            string fullUrl = "https://en.wikipedia.org/wiki/List_of_programmers";

            List<string> programmerLinks = new List<string>();

            // Build browser proxy to collect data
            var options = new LaunchOptions()
            {
                Headless = true,
                ExecutablePath = @"C:/Program Files (x86)/Google/Chrome/Application/chrome.exe"
            };
            var browser = await Puppeteer.LaunchAsync(options, null, Product.Chrome);
            var page = await browser.NewPageAsync();

            // Use browser proxy to collect links
            await page.GoToAsync(fullUrl);
            var links = @"Array.from(document.querySelectorAll('a')).map(a => a.href);";
            var urls = await page.EvaluateExpressionAsync<string[]>(links);

            // Parse links
            foreach (string url in urls)
            {
                programmerLinks.Add(url);
            }

            WriteToCsv(programmerLinks);

            return View();
        }

        public IActionResult Index()
        {
            string url = "https://en.wikipedia.org/wiki/List_of_programmers";

            var response = CallUrl(url).Result;
            var linkList = ParseHtml(response);
            WriteToCsv(linkList);

            return View();
        }
        */

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

            // Create list to contain the links
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

        private void WriteToCsv(List<string> links)
        {
            StringBuilder sb = new StringBuilder();

            // Add links to stringbuilder
            foreach (var link in links)
            {
                sb.Append(link);
            }

            string filepath = @"C:\Developer\scratch-pad\Dot-Net\c-sharp-webscraper\Other\links.csv";

            // Write stringbuilder to csv file
            System.IO.File.WriteAllText(filepath, sb.ToString());
        }
    }
}
