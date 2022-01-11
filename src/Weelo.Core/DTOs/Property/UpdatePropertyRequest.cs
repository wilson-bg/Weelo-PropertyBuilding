using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Core.DTOs
{
    public class UpdatePropertyRequest
    {

        [Required]
        public Int64 IdProperty { get; set; }
        
        public Int64? IdOwner { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        public decimal? Price { get; set; }

        [MaxLength(25)]
        public string CodeInternal { get; set; }

        public int? Year { get; set; }



    }
}
