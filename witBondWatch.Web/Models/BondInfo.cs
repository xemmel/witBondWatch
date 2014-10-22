using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using witBondWatch.Web.Helpers;

namespace witBondWatch.Web.Models
{
  public class BondInfo
  {
    public int Id { get; set; }
    public decimal Percentage { get; set; }
    public int YearExperation { get; set; }
    public decimal Value { get; set; }
    public decimal OfferValue { get; set; }
    public decimal Delta { get; set; }
    public string Issuer { get; set; }
    public string Description { get; set; }
    
    public int YearsLeft {
      get {
        if (YearExperation == 0)
          return 0;
        int yearNow = DateTime.Now.Year;
        return (YearExperation - yearNow);
      }
    }

    public decimal ActualPercentage { get {
      return LoanHelper.GetActualInterestRate(Value, Percentage);
    } }
  
    
  }
}