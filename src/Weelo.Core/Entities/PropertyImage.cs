using System;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Entities
{
    public class PropertyImage : IEntity
    {

        public Int64 IdPropertyImage { get; set; }

        public Int64 IdProperty { get; set; }

        public virtual Property Property { get; set; }


        public Byte[] File { get; set; }

        public bool Enable { get; set; }



    }
}
