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
            public static void getRequest(string sURL)
            {
                try
                {
                    Console.WriteLine("Get request:");
                    WebRequest wrGETURL;
                    wrGETURL = WebRequest.Create(sURL);
                    Stream objStream;
                    objStream = wrGETURL.GetResponse().GetResponseStream();
                    StreamReader objReader = new StreamReader(objStream);
              
                string sLine = "";

                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        Console.WriteLine(sLine);
                }
                    Console.Read();
                }
                catch (Exception ex)
                {
                    if (ex is System.Net.WebException)
                    {
                        Console.WriteLine("Website offline? Exception: " + ex);
                    }
                    else if (ex is System.UriFormatException)
                    {
                        Console.WriteLine("Wrong URL format! did you forget http:// ?  " + ex);
                    }
                    
                }

            }
           
        }
    }
}
