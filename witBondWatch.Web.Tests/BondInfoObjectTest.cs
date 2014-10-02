using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using witBondWatch.Web.Helpers;
using witBondWatch.Web.Models;

namespace witBondWatch.Web.Tests
{
  [TestClass]
  public class BondInfoObjectTest
  {
 
    [TestMethod]
    public void BondInfoObject_GetYearsLeft()
    {
      int expected = (47 - 14);
      BondInfo bi = new BondInfo() { YearExperation = 2047 };
      var result = bi.YearsLeft;
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void BondInfoObject_GetActualPercentage()
    {
      decimal expected = 0.02632m;

      BondInfo bi = new BondInfo() { YearExperation = 2047, Percentage = 0.025m, Value = 95 };
      var result = bi.ActualPercentage;
      Assert.AreEqual(Math.Round(expected,3), Math.Round(result,3));
    }

  }
}
