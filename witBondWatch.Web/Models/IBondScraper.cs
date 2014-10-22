using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace witBondWatch.Web.Models
{
  public interface IBondScraper
  {
    List<BondInfo> GetBonds();
    BondInfo GetBond(string bondDesc);
  }
}