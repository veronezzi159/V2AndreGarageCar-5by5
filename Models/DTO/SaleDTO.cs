using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public string CarPlate { get; set; }
        public DateTime SaleDate { get; set; }
        public Decimal SaleValue { get; set; }
        public string EmployeeDocument { get; set; }
        public string ClientDocument { get; set; }
        public int PaymentId { get; set; }
    }
}
