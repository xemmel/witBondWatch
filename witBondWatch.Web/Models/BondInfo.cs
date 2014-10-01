using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace witBondWatch.Web.Models
{
  public class BondInfo
  {
    public int Id { get; set; }
    public decimal Percentage { get; set; }
    public int YearExperation { get; set; }
    public decimal Value { get; set; }
    public decimal Delta { get; set; }
    public string Issuer { get; set; }
    public string Description { get; set; }
  }
}