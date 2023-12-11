using Construction.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Construction.Models;
using Construction.DataAccess.Repository;
using Construction.DataAccess.Repository.IRepository;
using System.ComponentModel;

namespace ConstructionManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Worker obj = _db.Worker.GetFirstOrDefault(u => u.WorkerId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Worker? obj = _db.Worker.GetFirstOrDefault(u => u.WorkerId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Worker.Remove(obj);
            _db.Save();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Worker? obj = _db.Worker.GetFirstOrDefault(u => u.WorkerId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(Worker worker)
        {
            if (ModelState.IsValid)
            {
                _db.Worker.Update(worker);
                _db.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
