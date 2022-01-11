using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weelo.Core.DTOs
{
    public class CreateOwnerRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public byte[] Photo { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

    }

}
