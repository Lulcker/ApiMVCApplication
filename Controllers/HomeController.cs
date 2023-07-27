using ApiMVCApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;

        public HomeController(ApplicationContext db)
        {
            this.db = db;
        }
             
        public async Task<ActionResult> Index()
        {
            var users = await db.Users
                                .Include(u => u.UserGroup)
                                .Include(u => u.UserState)
                                .ToListAsync();
            return View(users);
        }
        
    }
}
