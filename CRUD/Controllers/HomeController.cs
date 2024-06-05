using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CRUD.Models;
using CRUD.Data;
using Microsoft.EntityFrameworkCore;

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
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
