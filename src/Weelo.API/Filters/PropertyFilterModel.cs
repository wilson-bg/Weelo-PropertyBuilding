using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weelo.API.Filters
{
    public class PropertyFilterModel : BaseFilterModel
    {
        public PropertyFilterModel()
        {            
            this.MaxPageSize = 25;
        }

        public string Owner { get; set; }

        public string Address { get; set; }

        public decimal? MinPrice  { get; set; }

        public decimal? MaxPrice { get; set; }


        public override bool IsValid()
        {
            return base.IsValid();
        }

    }
}
