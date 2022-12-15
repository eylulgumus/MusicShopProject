using MusicShop.Data.Entities;
using MusicShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Repositories
{
    public class CustomerRepo:Repo<Customer>, ICustomerRepo
    {
        private ApplicationDbContext _context;
        public CustomerRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Customer customer)
        {
            var customerDB = _context.Customers.FirstOrDefault(x => x.Id == customer.Id);
            if (customerDB != null)
            {
                customerDB.Name = customer.Name;
                customerDB.Email = customer.Email;
                customerDB.Password=customer.Password;
            }
        }

	}
}
