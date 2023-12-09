using Construction.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Construction.Models;
using Construction.DataAccess.Repository;

namespace ConstructionManagementSystem.Controllers
{
    public class WorkerController : Controller
    {
        private readonly UnitOfWork _db;
        public WorkerController(UnitOfWork db)
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
