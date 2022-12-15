using MusicShop.Data.Entities;
using MusicShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Repositories
{
    public class OrderRepo:Repo<Order>, IOrderRepo
    {
        private ApplicationDbContext _context;
        public OrderRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Order order)
        {
            var orderDb = _context.Orders.FirstOrDefault(x => x.Id == order.Id);
            if (orderDb != null)
            {
                orderDb.Quantity = order.Quantity;
            }
        }
    }
}
