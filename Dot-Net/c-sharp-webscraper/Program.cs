﻿using HtmlAgilityPack;
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
            var mainPageLinks = GetMainPageLinks("https://www.indeed.co.uk/jobs?q=data+scientist&l=liverpool");

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

            // Check links and add if linked to job
            foreach(var link in links)
            {
                if(link.Attributes["href"].Value.Contains(".html"))
                {
                    try
                    {
                        homePageLinks.Add(link.Attributes["href"].Value);
                    }
                    catch
                    {
                    }
                }
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
    }
}
