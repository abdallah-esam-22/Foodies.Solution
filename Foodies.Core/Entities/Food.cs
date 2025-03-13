using Foodies.Core.Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Entities
{
    public class Food : BaseEntity, IPicturable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal UnitPrice { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
