using MusicShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.ViewModels
{
    public class CustomerVM
    {
        public Customer Customer { get; set; } = new Customer();
        public IEnumerable<Customer> customers { get; set; } = new List<Customer>();
		public void MapFromModel(Customer customer)
		{
			this.Customer = customer;
			
		}
	}
}
