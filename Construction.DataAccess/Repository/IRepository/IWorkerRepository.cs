using Construction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.DataAccess.Repository.IRepository
{
    public interface IWorkerRepository:IRepository<Worker>
    {
        void Update(Worker worker);
    }
}
