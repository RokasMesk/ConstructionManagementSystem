using Construction.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Construction.Models;
using Construction.DataAccess.Repository;
using Construction.DataAccess.Repository.IRepository;
using System.ComponentModel;

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Worker obj)
        {
            if (ModelState.IsValid)
            {
                _db.Worker.Add(obj);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
