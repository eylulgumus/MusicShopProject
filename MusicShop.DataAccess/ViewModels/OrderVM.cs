using Microsoft.AspNetCore.Mvc.Rendering;
using MusicShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.ViewModels
{
    public class OrderVM
    {
        public Order Order { get; set; } = new Order();
        public IEnumerable<Order> orders { get; set; } = new List<Order>();
        public IEnumerable<SelectListItem> instruments { get; set; }
		public IEnumerable<SelectListItem> customers { get; set; }
    }
}
