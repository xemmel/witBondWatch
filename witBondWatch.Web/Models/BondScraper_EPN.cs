using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using witBondWatch.Web.Helpers;

namespace witBondWatch.Web.Models
{
  public class BondScraper_EPN : IBondScraper
  {
    private const string url = "http://epn.dk/kurs/obligationer/";
    private const string rawXPath = "(?<=<div class=\"graphTitle\">)(.|\\n|\\r)*?(?=</div>)";

    string wholeBondTitleReg = "(?<=<span class=\"graphTitle1\">)(.|\\n|\\r)*?(?=</span>)";
    string wholeBondPercentReg = ".*?(?=%)";
    string wholeBondYearReg = "(?<=%-).*?(?= \\()";

    string ValueReg = "(?<=<span class=\"graphTitle2\">)(.|\\n|\\r)*?(?=</span>)";
    string DeltaReg = "(?<=<span class=\"(red|green)_graphTitle3\">)(.|\\n|\\r)*?(?=%</span>)";
 

    public List<BondInfo> GetBonds()
    {
      List<BondInfo> output = new List<BondInfo>();
      var rawList = ScreenScraperHelper.GetRawScreenMatches(url, rawXPath);
      foreach (var rawItem in rawList)
      {
        string sValue = Regex.Match(rawItem, ValueReg).Value.Replace(",", ".");
        decimal dValue = 0;
        bool success = Decimal.TryParse(sValue, out dValue);
        string sDelta = Regex.Match(rawItem, DeltaReg).Value.Replace(",", ".");
        decimal dDelta = 0;
        string sTitle = Regex.Match(rawItem, wholeBondTitleReg).Value;

        string sPercentage = Regex.Match(sTitle, wholeBondPercentReg).Value.Replace(",", ".");
        decimal dPercentage = 0;
        success = Decimal.TryParse(sPercentage, out dPercentage);

        string sYear = Regex.Match(sTitle, wholeBondYearReg).Value.Replace(",", ".");
        int iYear = 0;
        success = Int32.TryParse(sYear, out iYear);


        success = Decimal.TryParse(sDelta, out dDelta);
        BondInfo bi = new BondInfo()
        {
          Description = rawItem,
          Delta = dDelta,
          Value = dValue,
          Issuer = sTitle,
          Percentage = dPercentage,
          YearExperation = iYear
        };
        output.Add(bi);
      }
      return output;
    }

    public BondInfo GetBond(string bondDesc)
    {
      var bondList = GetBonds();
      BondInfo output = bondList.Where(b => (b.Issuer == bondDesc)).FirstOrDefault();
      return output;
    }
  }
}