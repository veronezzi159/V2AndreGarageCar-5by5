using Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CNH
    {
        [Key]
        public string Cnh {  get; set; }
        public DateTime DueDate { get; set; }
        public string Rg {  get; set; }
        public string Cpf { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public Category? Category { get; set; }


        public CNH()
        {
        }

        public CNH(CNHDTO dto)
        {
            
            Cnh = dto.Cnh;
            DueDate = dto.DueDate;
            Rg = dto.Rg;
            Cpf = dto.Cpf;
            MotherName = dto.MotherName;
            FatherName = dto.FatherName;
            
        }
        
    }
}
