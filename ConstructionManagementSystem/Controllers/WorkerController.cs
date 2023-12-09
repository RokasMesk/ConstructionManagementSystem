using Construction.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Construction.Models;
namespace ConstructionManagementSystem.Controllers
{
    public class WorkerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public WorkerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
