using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Core.DTOs
{
    public class UpdatePropertyPriceRequest
    {
        [Required]
        public Int64 IdProperty { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}
