using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace witBondWatch.Web.Helpers
{
  public class LoanHelper
  {

    /// <summary>
    /// If you need 100.000 kr and the rate is 95 you will need 105263 (100000 * (100/95))
    /// </summary>
    /// <param name="rate"></param>
    /// <param name="loanNeeded"></param>
    /// <returns></returns>
    public static decimal GetLoanAmount(decimal rate, decimal loanNeeded)
    {
      return (loanNeeded * (100 / rate));
    }



    public static decimal GetActualInterestRate(decimal rate, decimal interest)
    {
      return (interest * (100 / rate));
    }
  }
}