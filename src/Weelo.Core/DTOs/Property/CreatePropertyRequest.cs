using System;
using System.ComponentModel.DataAnnotations;

namespace Weelo.Core.DTOs
{
    public class CreatePropertyRequest
    {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets the code internal.
        /// </summary>
        /// <value>
        /// The code internal.
        /// </value>
        [MaxLength(25)]
        public string CodeInternal { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int? Year { get; set; }


        [Required]
        public Int64 IdOwner { get; set; }


    }
}
