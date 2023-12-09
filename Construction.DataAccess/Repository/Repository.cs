using Construction.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.DataAccess.Repository
{
    public class Repository: IRepository<T> where T: class 
    {
    }
}
