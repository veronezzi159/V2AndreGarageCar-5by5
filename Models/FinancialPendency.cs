using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FinancialPendency
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime PendencyDate { get; set; }
        public DateTime BillingDate { get; set; }
        public decimal Value { get; set; }
        public Client? Client { get; set; }
        public bool Status { get; set; }

        public FinancialPendency()
        {
            
        }
        public FinancialPendency(FinancialPendencyDTO dTO, Client c)
        {
            Id = dTO.Id;
            Description = dTO.Description;
            PendencyDate = dTO.PendencyDate;
            BillingDate = dTO.BillingDate;
            Value = dTO.Value;
            this.Client = c;
            Status = dTO.Status;
            
        }
    }
}
