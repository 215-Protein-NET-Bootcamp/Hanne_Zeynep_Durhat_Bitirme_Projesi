using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projesi_Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        Task CompleteAsync();
    }
}
