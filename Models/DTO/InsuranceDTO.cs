using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class InsuranceDTO
    {
        public int Id { get; set; }
        
        public string ClientDocument { get; set; }
        public decimal Franchise { get; set; }
        public string CarPlate { get; set; }
        public string DriverDocument { get; set; }  
    }
}
