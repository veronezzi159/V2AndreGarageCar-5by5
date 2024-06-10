using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public string CarPlate { get; set; }
        public Decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
