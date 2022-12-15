using MusicShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICustomerRepo Customer { get; private set; }
        public INstrumentRepo Nstrument { get; private set; }
        public IOrderRepo Order { get; private set; }
        public ImanufacturerRepo Manufacturer { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Customer = new CustomerRepo(context);
            Nstrument = new InstrumentRepo(context);
            Manufacturer = new ManufacturerRepo(context);
            Order = new OrderRepo(context);

        }
        public void save()
        {
            _context.SaveChanges();
        }
    }
}
