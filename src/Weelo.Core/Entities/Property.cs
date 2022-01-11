using System;
using System.Collections.Generic;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Entities
{
    /// <summary>
    /// The property
    /// </summary>
    /// <seealso cref="IEntity" />
    public class Property : IEntity
    {
        /// <summary>
        /// Gets or sets the property identifier.
        /// </summary>
        /// <value>
        /// The property identifier.
        /// </value>
        public Int64 IdProperty { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
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
        public string CodeInternal { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int? Year { get; set; }


        public Int64 IdOwner { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public virtual Owner Owner { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        public bool Deleted { get; set; }


        public ICollection<PropertyImage> Images { get; set; }
        public ICollection<PropertyTrace> Traces { get; set; }
    }
}
