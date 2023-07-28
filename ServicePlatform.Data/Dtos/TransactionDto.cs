using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePlatform.Data.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? IsCompleted { get; set; }

        public bool? IsExpertApproved { get; set; }

        public string? Message { get; set; }

        public int? ExpertId { get; set; }

        public int? ServiceId { get; set; }

        public int? CustomerId { get; set; }
    }
}
