using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace witBondWatch.Web.Helpers
{
  public class ScreenScraperHelper
  {
    public static List<string> GetRawScreenMatches(string addressUrl, string xpath)
    {
      List<string> output = new List<string>();
      string rawHTML = GetRawScreen(addressUrl);
      var matches = Regex.Matches(rawHTML, xpath);
      foreach (Match match in matches)
      {
        output.Add(match.Value);
      }
      return output;
    }

    public static string GetRawScreen(string addressUrl)
    {
      WebClient webClient = new WebClient();

      return webClient.DownloadString(addressUrl);
    }
  }
}