using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Core.DTOs
{
    public class ListPropertyResponse
    {
        public IList<PropertyResponse> Properties { get; set; }
        public bool HasNextPage { get; set; }
        public int TotalCount { get; set; }
    }
}
