using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities
{
    public class Nstrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantInStock { get; set; }
        public int ManufacturerId { get; set; }
    }

}
