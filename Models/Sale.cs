using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO;
namespace Models
{
    public  class Sale
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public DateTime SaleDate { get; set; }
        public Decimal SaleValue { get; set; }
        public Employee Employee { get; set; }
        public Client Client { get; set; }
        public Payment Payment { get; set; }

        public Sale() { }

        public Sale(SaleDTO saleDTO)
        {
            Id = saleDTO.Id;
            Car car = new Car() { Plate = saleDTO.CarPlate };
            Car = car;
            SaleDate = saleDTO.SaleDate;
            SaleValue = saleDTO.SaleValue;
            Employee employee = new Employee() { Document = saleDTO.EmployeeDocument };
            Employee = employee;
            Client client = new Client() { Document = saleDTO.ClientDocument };
            Client = client;
            Payment payment = new Payment() { Id = saleDTO.PaymentId };
            Payment = payment;
        }
    
    }
}
