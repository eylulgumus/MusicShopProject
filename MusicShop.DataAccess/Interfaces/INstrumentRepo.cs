using MusicShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Interfaces
{
    public interface INstrumentRepo : IRepo<Nstrument>
    {
        void Update(Nstrument instrument);
    }
}
