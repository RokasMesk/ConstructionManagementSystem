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
    public class ProjectRepository: Repository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _db;
        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }
        public void Update(Project obj)
        {
            _db.Projects.Update(obj);
        }
    }
}
