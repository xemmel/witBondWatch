using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using witBondWatch.Web.Helpers;

namespace witBondWatch.Web.Models
{
  public class BondScraper_NyKredit : IBondScraper
  {
    private const string url = "http://www.nykredit.dk/kursoversigt/kursoversigt.do?iwID=/privat/beregningsside/realkredit/kursoversigt/kursoversigt_udbetaling.xml";
    private const string rawXPath = "(?<=<tr class=\"(even|odd|even first|odd first|odd last|even last)\">)(.|\\n|\\r)*?(?=</tr>)";

    string wholeBondTitleReg = "(?<=<td>)DK[0-9]*";
    string wholeBondPercentReg = "(?<=<td align=\"center\" class=\"text\">)(.|\r|\n)*?(?=%</td>)";
    string wholeBondYearReg = "(?<=<td align=\"center\" class=\"text\">[a-z]{3}\\. )[0-9]*?(?=</td>)";

    string ValueReg = "(?<=<td align=\"right\">)(.|\r|\n)*?(?=</td>)";
    string DeltaReg = "(?<=<span class=\"decData\">)(.|\\n|\\r)*?(?=%</span>)";
 
    public List<BondInfo> GetBonds()
    {
      List<BondInfo> output = new List<BondInfo>();
      var rawList = ScreenScraperHelper.GetRawScreenMatches(url, rawXPath);
      foreach (var rawItem in rawList)
      {
        string sValue = Regex.Matches(rawItem, ValueReg)[0].Value.Replace(",", ".").Trim();
        decimal dValue = 0;
        bool success = Decimal.TryParse(sValue, out dValue);

        string sOfferValue = Regex.Matches(rawItem, ValueReg)[1].Value.Replace(",", ".").Trim();
        decimal dOfferValue = 0;
        success = Decimal.TryParse(sOfferValue, out dOfferValue);
    
        string sDelta = Regex.Match(rawItem, DeltaReg).Value.Replace(",", ".");
        decimal dDelta = 0;
        string sTitle = Regex.Match(rawItem, wholeBondTitleReg).Value;

        string sPercentage = Regex.Match(rawItem, wholeBondPercentReg).Value.Replace(",", ".");
        decimal dPercentage = 0;
        success = Decimal.TryParse(sPercentage, out dPercentage);

        string sYear = Regex.Match(rawItem, wholeBondYearReg).Value;
        int iYear = 0;
        success = Int32.TryParse(sYear, out iYear);


        success = Decimal.TryParse(sDelta, out dDelta);
        BondInfo bi = new BondInfo()
        {
          Description = rawItem,
          Delta = dDelta,
          Value = dValue,
          OfferValue = dOfferValue,
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