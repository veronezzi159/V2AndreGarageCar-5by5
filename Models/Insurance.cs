using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Insurance
    {
        public static readonly string INSERT = "INSERT INTO Insurance (ClientDocument,Franchise, CarPlate, DriverDocument) values (@ClientDocument, @Franchise, @CarPlate, @DriverDocument)";
        public static readonly string SELECT = "SELECT i.Id, i.Franchise, cl.Document,cl.Income, pc.Name,pc.Phone, car.Plate, car.Name, car.FabricationYear, car.Color, " +
                                                "d.Document, pd.Name, pd.Phone, cnh.Cnh, cnh.DueDate,cnh.Rg,cnh.Cpf,cnh.MotherName,cnh.FatherName,cat.Id,cat.Description FROM Insurance i " +
                                                "INNER JOIN Car car ON i.CarPlate = car.Plate " +
                                                "INNER JOIN Client cl ON i.ClientDocument = cl.Document " +
                                                "INNER JOIN Driver d ON i.DriverDocument = d.Document " +
                                                "INNER JOIN Person pc ON cl.Document = pc.Document " +
                                                "INNER JOIN Person pd ON d.Document = pd.DOcument " +
                                                "INNER JOIN CNH cnh ON d.Cnh = cnh.Cnh " +
                                                "INNER JOIN Category cat ON cat.Id = cnh.CategoryId";
        public int Id { get; set; }
        public Client Client { get; set; }

        public Decimal Franchise { get; set; }
        public Car Car { get; set; }

        public Driver? Driver { get; set; }
    }
}
