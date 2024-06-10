using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO;

namespace Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public Decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Purchase() { }

        public Purchase(PurchaseDTO purchaseDTO)
        {
            Id = purchaseDTO.Id;
            Car car = new Car() { Plate  = purchaseDTO.CarPlate};
            Car = car;
            Price = purchaseDTO.Price;
            PurchaseDate = purchaseDTO.PurchaseDate;
        }
    }
}
