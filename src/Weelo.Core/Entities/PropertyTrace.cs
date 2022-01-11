using System;

namespace Weelo.Core.Entities
{
    public class PropertyTrace
    {
        public Int64 IdPropertyTrace { get; set; }

        public Int64 IdProperty { get; set; }

        public Property Property { get; set; }

        public DateTime DateSale { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public decimal Tax { get; set; }

    }
}
