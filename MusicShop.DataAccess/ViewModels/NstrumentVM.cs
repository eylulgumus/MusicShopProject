using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.ViewModels
{
    public class NstrumentVM
    {
        public Nstrument Instrument { get; set; } = new Nstrument();
        public IEnumerable<Nstrument> instruments { get; set; } = new List<Nstrument>();
		public IEnumerable<SelectListItem> manufacturers { get; set; }
		public void MapFromModel(Nstrument nstrument)
		{
			this.Instrument = nstrument;

		}
	}
}
