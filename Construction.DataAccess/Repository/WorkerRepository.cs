using Construction.DataAccess.Data;
using Construction.DataAccess.Repository.IRepository;
using Construction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.DataAccess.Repository
{
    public class WorkerRepository: Repository<Worker>, IWorkerRepository
    {
        private readonly ApplicationDbContext _db;
        public WorkerRepository(ApplicationDbContext db):base(db)
        {
            _db=db;
        }
        public void Update(Worker obj)
        {
            _db.Workers.Update(obj);
        }
    }
}
