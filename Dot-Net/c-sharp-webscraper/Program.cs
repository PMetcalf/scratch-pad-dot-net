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
            Console.WriteLine("Hello World!");
        }

        // Method returns HTML
        static HtmlNode GetHtml(string url)
        {
            WebPage webPage = _browser.NavigateToPage(new Uri(url));

            return webPage.Html;
        }
    }
}
