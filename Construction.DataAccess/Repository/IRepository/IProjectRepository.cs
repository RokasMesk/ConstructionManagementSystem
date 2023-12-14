using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Construction.Models;

namespace Construction.DataAccess.Repository.IRepository
{
    public interface IProjectRepository:IRepository<Project>
    {
        void Update(Project project);
    }
}
