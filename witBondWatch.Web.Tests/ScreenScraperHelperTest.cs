using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using witBondWatch.Web.Helpers;

namespace witBondWatch.Web.Tests
{
  [TestClass]
  public class ScreenScraperHelperTest
  {
    private const string url = "http://epn.dk/kurs/obligationer/";
    //private const string rawXPath = "<div class=\"graphTitle\">\r\n.*\r\n.*\r\n.*\r\n.*\r\n.*</div>";
    private const string rawXPath = "(?<=<div class=\"graphTitle\">)(.|\\n|\\r)*?(?=</div>)";
    [TestMethod]
    public void ScreenScraperHelper_GetRawScreen()
    {
      int expectedlength = 1000;
      string result = ScreenScraperHelper.GetRawScreen(url);
      Assert.IsTrue(result.Length >= expectedlength, "HTML returned not long enough!");
    }

    [TestMethod]
    public void ScreenScraperHelper_GetRawScreenMatches()
    {
      int expectedCount = 6;
      var result = ScreenScraperHelper.GetRawScreenMatches(url, rawXPath);
      Assert.IsTrue(result.Count == expectedCount, "Count doesn't match!");
    }
  }
}
