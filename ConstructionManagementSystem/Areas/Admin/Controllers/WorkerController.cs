using Construction.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Construction.Models;
using Construction.DataAccess.Repository;
using Construction.DataAccess.Repository.IRepository;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Construction.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConstructionManagementSystem.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class WorkerController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public WorkerController(IUnitOfWork db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var workersFromDb = _db.Worker.GetAll();
            return View(workersFromDb);
        }
        public IActionResult RegisterWorker()
        {
            var model = new RegisterVM
            {
                // Populate the list of roles
                PossibleRoles = new List<SelectListItem>
                {
                new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Employee", Text = "Employee" }
                }
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult RegisterWorker(RegisterVM obj)
        {
            if (ModelState.IsValid)
            {
                Worker worker = new Worker()
                {
                    Name = obj.Name,
                    LastName = obj.LastName,
                    Title = obj.Title,
                    PhoneNumber = obj.PhoneNumber
                };
                _db.Worker.Add(worker);
                _db.Save();
                ApplicationUser user = new ApplicationUser()
                {
                    Email = obj.Email,
                    WorkerId = worker.WorkerId,
                    UserName = obj.Email,
                };
                var result = _userManager.CreateAsync(user, obj.Password).GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    // Adding the "Admin" role to the admin user
                    var fromDb = _userManager.FindByEmailAsync(obj.Email).GetAwaiter().GetResult();
                    _userManager.AddToRoleAsync(fromDb, obj.Role).GetAwaiter().GetResult();
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong, please try again");
                }
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
