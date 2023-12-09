using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IWorkerRepository Worker { get; }
        void Save();
    }
}
