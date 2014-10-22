using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using witBondWatch.Web.Helpers;

namespace witBondWatch.Web.Tests
{
  [TestClass]
  public class ScreenScraperBondHelperTest
  {
    [TestMethod]
    public void ScreenScraperBondHelperTest_GetBonds()
    {
      int expectedCount = 2;
      var result = ScreenScraperBondHelper.GetBonds();
      Assert.AreEqual(expectedCount, result.Count);
    }

    [TestMethod]
    public void ScreenScraperBondHelperTest_GetSpecificBond()
    {
      string issuer = "DK0009798993";
      var result = ScreenScraperBondHelper.GetSpecificBond(issuer);
      Assert.IsFalse(result == null);
    }
  }
}
