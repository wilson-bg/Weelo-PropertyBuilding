using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weelo.API.Filters
{
    public class ApiError
    {
        public string Code { get; set; }

        public IList<ApiError> Details { get; set; }

        public string Message { get; set; }

        public string Target { get; set; }
    }
}
