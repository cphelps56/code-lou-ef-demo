using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ef_demo
{
    public class Test
    {
        public Test()
        {
            PriceOptions = new List<Options>
            {
                new Options { Key = 0, LowerValue = 0, UpperValue = 2500000,
                new Options { Key = 1, LowerValue = 2500001, UpperValue = 350000 }
            };

        }
        public List<Options> PriceOptions { get; set; }
        public List<SelectListItem> PriceSelectListItems => PriceOptions.Select(x => new SelectListItem { Value = x.Key, Text = x.FriendlyString });
    }

    public enum PriceRanges
    {
        ZeroTo250000 = 1,

    }
    public class Options
    {
        public int Key { get; set; }
        public int LowerValue { get; set; }
        public int UpperValue { get; set; }
        public string FriendlyString => $"{LowerValue}-{UpperValue}";
    }
}
