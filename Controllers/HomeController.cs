using ApiMVCApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

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
        
        public async Task<IActionResult> Create()
        {
            int countAdmin = await db.Users.CountAsync(u => u.UserGroupId == 1 && u.UserStateId != 2);
            ViewBag.CountAdmin = countAdmin < 1;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User? user = await db.Users
                    .Include(g => g.UserGroup)
                    .Include(s => s.UserState)
                    .FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                User? user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                user.UserStateId = 2;
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
