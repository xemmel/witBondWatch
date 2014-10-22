using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace witBondWatch.Web.Helpers
{
  public class ScreenScraperHelper
  {


    /// <summary>
    /// Only works if HTML is valid XML
    /// </summary>
    /// <param name="addressUrl"></param>
    /// <param name="xpath"></param>
    /// <returns></returns>
    public static List<string> GetRawScreenMatchesXPath(string addressUrl, string xpath)
    {
      List<string> output = new List<string>();
      string rawHTML = GetRawScreen(addressUrl);
      XmlDocument xdoc = new XmlDocument();
      xdoc.LoadXml(rawHTML);
      var matches = xdoc.SelectNodes(xpath);
      foreach (XmlNode match in matches)
      {
        output.Add(match.Value);
      }
      return output;
    }
    public static List<string> GetRawScreenMatches(string addressUrl, string regex)
    {
      List<string> output = new List<string>();
      string rawHTML = GetRawScreen(addressUrl);
      var matches = Regex.Matches(rawHTML, regex);
      foreach (Match match in matches)
      {
        output.Add(match.Value);
      }
      return output;
    }

    public static string GetRawScreen(string addressUrl)
    {
      WebClient webClient = new WebClient();
      //webClient.Headers["Method"] = "GET";
      //webClient.Headers["Accept"] = "application/xml";
      webClient.Encoding = Encoding.UTF8;
      return webClient.DownloadString(addressUrl);
    }
  }
}