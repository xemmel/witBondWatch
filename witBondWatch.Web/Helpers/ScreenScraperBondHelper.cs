using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using witBondWatch.Web.Models;

namespace witBondWatch.Web.Helpers
{
  public class ScreenScraperBondHelper
  {
    private const string url = "http://epn.dk/kurs/obligationer/";
    private const string rawXPath = "(?<=<div class=\"graphTitle\">)(.|\\n|\\r)*?(?=</div>)";

    public static List<BondInfo> GetBonds()
    {
      string wholeBondTitleReg = "(?<=<span class=\"graphTitle1\">)(.|\\n|\\r)*?(?=</span>)";
      string ValueReg = "(?<=<span class=\"graphTitle2\">)(.|\\n|\\r)*?(?=</span>)";
      string DeltaReg = "(?<=<span class=\"(red|green)_graphTitle3\">)(.|\\n|\\r)*?(?=%</span>)";


      List<BondInfo> output = new List<BondInfo>();
      var rawList = ScreenScraperHelper.GetRawScreenMatches(url, rawXPath);
      foreach (var rawItem in rawList)
      {
        string sValue = Regex.Match(rawItem, ValueReg).Value.Replace(",", ".");
        decimal dValue = 0;
        bool success = Decimal.TryParse(sValue, out dValue);
        string sDelta = Regex.Match(rawItem, DeltaReg).Value.Replace(",",".");
        decimal dDelta =  0;
        string sTitle = Regex.Match(rawItem, wholeBondTitleReg).Value;

        success = Decimal.TryParse(sDelta, out dDelta);
        BondInfo bi = new BondInfo() { Description = rawItem, Delta = dDelta, Value = dValue,Issuer = sTitle };
        output.Add(bi);
      }
      return output;
    }

    public static BondInfo GetSpecificBond(string issuer)
    {
      var bondList = GetBonds();
      BondInfo output = bondList.Where(b => (b.Issuer == issuer)).FirstOrDefault();
      return output;

    }
  }
}