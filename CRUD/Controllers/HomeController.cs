using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CRUD.Models;
using CRUD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
       private readonly ApplicationDBContext _dbContext;

        public HomeController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Users.ToListAsync());
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(User user) {

            if (ModelState.IsValid)
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
