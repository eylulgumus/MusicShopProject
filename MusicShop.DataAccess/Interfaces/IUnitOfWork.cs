using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepo Customer { get; }
        INstrumentRepo Nstrument { get; }
        ImanufacturerRepo Manufacturer { get; }
        IOrderRepo Order { get; }
        void save();

    }
}
