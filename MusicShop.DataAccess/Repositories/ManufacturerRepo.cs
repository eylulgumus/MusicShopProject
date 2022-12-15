using MusicShop.Data.Entities;
using MusicShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Repositories
{
    public class ManufacturerRepo:Repo<Manufacturer>, ImanufacturerRepo
    {
        private ApplicationDbContext _context;
        public ManufacturerRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Manufacturer manufacturer)
        {
            var manufacturerDb = _context.Manufacturers.FirstOrDefault(x => x.Id == manufacturer.Id);
            if (manufacturerDb != null)
            {
                manufacturerDb.Name = manufacturer.Name;
                manufacturerDb.Email = manufacturer.Email;
                manufacturerDb.PhoneNumber = manufacturer.PhoneNumber;
            }
        }

    }
}
