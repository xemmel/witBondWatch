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

    public static List<BondInfo> GetBonds()
    {
      IBondScraper bs = new BondScraper_NyKredit();
      return bs.GetBonds().Where(b => ((b.YearExperation >= 2027) && (b.Value < 100))).ToList();
    }



    public static BondInfo GetSpecificBond(string issuer)
    {
      IBondScraper bs = new BondScraper_NyKredit();
      return bs.GetBond(issuer);


    }
  }
}