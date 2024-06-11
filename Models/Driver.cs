using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Driver : Person
    {
        public CNH CNH { get; set; }

        public Driver()
        {
        }
        public Driver(DriverDTO dto,Adress adress,CNH cnh)
        {
            this.Document = dto.Document;
            this.Name = dto.Name;
            this.BirthDate = dto.BirthDate;
            this.Adress = adress;
            this.Email = dto.Email;
            this.Phone = dto.Phone;
            this.CNH = cnh;
        }
    }
}
