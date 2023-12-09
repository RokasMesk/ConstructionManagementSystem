﻿using Construction.DataAccess.Data;
using Construction.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.DataAccess.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IWorkerRepository Worker { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Worker = new WorkerRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}