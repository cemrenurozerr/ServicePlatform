using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePlatform.Data.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }

        public int? IlId { get; set; }

        public int? IlceId { get; set; }

        public int? MahalleId { get; set; }
    }
}
