using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class FinancialPendencyDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime PendencyDate { get; set; }
        public DateTime BillingDate { get; set; }
        public decimal Value { get; set; }
        public string DocumentClient { get; set; }
        public bool Status { get; set; }
    }
}
