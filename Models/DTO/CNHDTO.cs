using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class CNHDTO 
    {
        public string Cnh { get; set; }
        public DateTime DueDate { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public Int64 CategoryId { get; set; }
    }
}
