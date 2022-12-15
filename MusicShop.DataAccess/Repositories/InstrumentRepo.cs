using MusicShop.Data.Entities;
using MusicShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Repositories
{
    public class InstrumentRepo:Repo<Nstrument>, INstrumentRepo
    {
        private ApplicationDbContext _context;
        public InstrumentRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Nstrument instrument)
        {
            var instrumentDb = _context.Nstruments.FirstOrDefault(x => x.Id == instrument.Id);
            if (instrumentDb != null)
            {
                instrumentDb.Name = instrument.Name;
                instrumentDb.Price = instrument.Price;
                instrumentDb.QuantInStock=instrument.QuantInStock;

            }
        }

    }
}
