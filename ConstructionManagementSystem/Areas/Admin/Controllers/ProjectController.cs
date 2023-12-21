
using Construction.DataAccess.Repository.IRepository;
using Construction.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NuGet.LibraryModel;

namespace ConstructionManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _db;
        public ProjectController(IUnitOfWork db) { _db = db; }
        public IActionResult Index()
        {

            var projects = _db.Project.GetAll(includeProperties:"ProjectWorkers");
            return View(projects);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _db.Project.Add(project);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Project project = _db.Project.GetFirstOrDefault(u => u.ProjectId == id, includeProperties: "ProjectWorkers");
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        [HttpPost]
        public IActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                _db.Project.Update(project);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Project? project = _db.Project.GetFirstOrDefault(u => u.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Project? project = _db.Project.GetFirstOrDefault(u => u.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }
            _db.Project.Remove(project);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}
