using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Core.DTOs
{
    public class UpdateOwnerRequest
    {
        [Required]
        public Int64 IdOwner { get; set; }

        public string Name { get; set; }
        
        public string Address { get; set; }

        public byte[] Photo { get; set; }


        public DateTime? Birthday { get; set; }
    }
}
