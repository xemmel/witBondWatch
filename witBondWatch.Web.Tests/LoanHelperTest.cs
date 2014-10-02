using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using witBondWatch.Web.Helpers;

namespace witBondWatch.Web.Tests
{
  [TestClass]
  public class LoanHelperTest
  {
    [TestMethod]
    public void LoanHelper_GetLoanAmount()
    {
      decimal loanNeeded = 100000;
      decimal rate = 95;
      decimal expected = 105263;
      var result = LoanHelper.GetLoanAmount(rate, loanNeeded);
      result = Math.Round(result, 0);
      Assert.AreEqual(expected, result);
    }

  }
}
