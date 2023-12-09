using Construction.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Construction.Models;
using Construction.DataAccess.Repository;
using Construction.DataAccess.Repository.IRepository;

namespace ConstructionManagementSystem.Controllers
{
    public class WorkerController : Controller
    {
        private readonly IUnitOfWork _db;
        public WorkerController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var workersFromDb = _db.Worker.GetAll();
            return View(workersFromDb);
        }
    }
}
