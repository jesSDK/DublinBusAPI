using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace DublinBusAPI
{
    public class Class1
    {
        public class init
        {
            public static void doinit(string stopno){
                //html magic
                Console.WriteLine("Dublin Bus API Loaded...");
                HtmlWeb hweb = new HtmlWeb();
                Console.WriteLine("Connecting to RTPI...");
                HtmlDocument doc = hweb.Load("http://www.rtpi.ie/Popup_Content/WebDisplay/WebDisplay.aspx?stopRef=" + stopno);
                Console.WriteLine("Method 2: ");
                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//div[@class='gridContainer']/table"))
                {
                    Console.WriteLine("Found: " + table.Id);
                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {
                        Console.WriteLine("row");
                        foreach (HtmlNode cell in row.SelectNodes("th|td"))
                        {
                            Console.WriteLine("cell: " + cell.InnerText);
                        }
                        Console.Read();
                    }
                }
            }
           
        }
    }
}
