using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public int NtsrumentId { get; set; }
  
    }

}
