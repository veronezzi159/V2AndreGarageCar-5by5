using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public Client Client { get; set; }

        public Decimal Franchise { get; set; }
        public Car Car { get; set; }

        public Driver? Driver { get; set; }
    }
}
