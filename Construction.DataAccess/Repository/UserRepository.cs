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
    public class UserRepository: Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }
        public void Update(User obj)
        {
            _db.Users.Update(obj);
        }
    }
}
