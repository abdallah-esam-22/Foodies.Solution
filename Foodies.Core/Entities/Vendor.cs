using Foodies.Core.Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Entities
{
    public class Vendor : BaseEntity, IPicturable
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
    }
}
