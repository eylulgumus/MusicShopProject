using MusicShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.ViewModels
{
    public class ManufacturerVM
    {
        public Manufacturer Manufacturer { get; set; } = new Manufacturer();
        public IEnumerable<Manufacturer> manufacturers { get; set; } = new List<Manufacturer>();
        public IEnumerable<string> manufactureSS { get; set; } = new List<string>();
		public void MapFromModel(Manufacturer manufacture)
		{
			this.Manufacturer = manufacture;

		}
	}
}
