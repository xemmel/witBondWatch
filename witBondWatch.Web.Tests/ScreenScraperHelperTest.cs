using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using witBondWatch.Web.Helpers;

namespace witBondWatch.Web.Tests
{
  [TestClass]
  public class ScreenScraperHelperTest
  {
    private const string url1 = "http://epn.dk/kurs/obligationer/";
    private const string url2 = "https://netbank.totalkredit.dk/netbank/showStockExchange.do";
    private const string rawRegEx = "(?<=<div class=\"graphTitle\">)(.|\\n|\\r)*?(?=</div>)";
    private const string rawRegEx2 = "(?<=<tr>)(.|\\n|\\r)*?(?=</tr>)";

    private const string rawXPath = "//table[@class=\"printtable\"]/tr";
    [TestMethod]
    public void ScreenScraperHelper_GetRawScreen()
    {
      int expectedlength = 1000;
      string result = ScreenScraperHelper.GetRawScreen(url1);
      Assert.IsTrue(result.Length >= expectedlength, "HTML returned not long enough!");
    }

    [TestMethod]
    public void ScreenScraperHelper_GetRawScreenMatches()
    {
      int expectedCount = 6;
      var result = ScreenScraperHelper.GetRawScreenMatches(url1, rawRegEx);
      Assert.AreEqual(expectedCount, result.Count);
    }

    [TestMethod]
    public void ScreenScraperHelper_GetRawScreenMatches_NyKre()
    {
      int expectedCount = 21;
      var result = ScreenScraperHelper.GetRawScreenMatches(url2, rawRegEx2);
      Assert.AreEqual(expectedCount, result.Count);
    }



    //[TestMethod]
    //public void ScreenScraperHelper_GetRawScreenMatchesXPath()
    //{
    //  int expectedCount = 10;
    //  var result = ScreenScraperHelper.GetRawScreenMatchesXPath(url2, rawXPath);
    //  Assert.AreEqual(expectedCount, result.Count);
    //}
  }
}
