using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pix
    {
        public int Id { get; set; }
        public PixType Type { get; set; }
        public string Key { get; set; }

        public Pix()
        {
        }

        public Pix(PixTypeDTO pixTypeDTO)
        {
            PixType pixType = new PixType { Id = pixTypeDTO.TypeID};
            Type = pixType;
            this.Key = pixTypeDTO.KeyPix;
        }
    }
}
