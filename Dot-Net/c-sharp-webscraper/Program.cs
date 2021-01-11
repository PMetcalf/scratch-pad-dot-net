using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;

namespace c_sharp_webscraper
{
    class Program
    {
        // ScrapingBrowser mimics real browser
        static ScrapingBrowser _browser = new ScrapingBrowser();

        static void Main(string[] args)
        {   
            var url = "https://newyork.craigslist.org/d/computer-gigs/search/cpg";
            //var url = "https://www.indeed.co.uk/jobs?q=data+scientist&l=liverpool";

            var mainPageLinks = GetMainPageLinks(url);

            Console.ReadLine();
        }

        // Returns links to jobs on a page
        static List<String> GetMainPageLinks(string url)
        {
            var homePageLinks = new List<string>();
            
            // Retrieve the html
            var html = GetHtml(url);

            // Filter for appropriate tag
            var links = html.CssSelect("a");

            try
            {
                // Check links and add if linked to job
                foreach(var link in links)
                {
                    if(link.Attributes["href"].Value.Contains(".html"))
                    {
                        homePageLinks.Add(link.Attributes["href"].Value);
                    }
                }
            }
            catch
            {
            }
            // Return links
            return homePageLinks;
        }

        // Returns HTML of particular webpage.
        static HtmlNode GetHtml(string url)
        {
            WebPage webPage = _browser.NavigateToPage(new Uri(url));

            return webPage.Html;
        }

        // Returns list of page details from HTML.
        static List<PageDetails> GetPageDetails(List<string> urls)
        {
            var listPageDetails = new List<PageDetails>();

            foreach (var url in urls)
            {
                var htmlNode = GetHtml(url);

                var pageDetails = new PageDetails();

                pageDetails.title = htmlNode.OwnerDocument.DocumentNode.SelectSingleNode("//html/head/title").InnerText;
                
                var description = htmlNode.OwnerDocument.DocumentNode.SelectSingleNode("//html/body/section/section/section/section").InnerText;

                pageDetails.description = description.Replace("\n        \n            QR Code Link to This Post\n            \n        \n", "");
            
                pageDetails.url = url;

                listPageDetails.Add(pageDetails);
            }

            return listPageDetails;
        }
    }

    public class PageDetails
    {
        public string title { get; set; }

        public string description { get; set; }

        public string url { get; set; }
    }
}
