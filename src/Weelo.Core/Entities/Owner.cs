using System;
using System.Collections.Generic;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Entities
{
    /// <summary>
    /// The owner
    /// </summary>
    /// <seealso cref="IEntity" />
    public class Owner : IEntity
    {
       
        /// <summary>
        /// Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        /// The owner identifier.
        /// </value>
        public Int64 IdOwner { get; set; }

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
        /// Gets or sets the photo.
        /// </summary>
        /// <value>
        /// The photo.
        /// </value>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        /// <value>
        /// The birthday.
        /// </value>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Owner"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Owner"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        public bool Deleted { get; set; }

        public ICollection<Property> Properties { get; set; }

    }
}
