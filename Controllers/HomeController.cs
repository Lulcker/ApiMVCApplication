﻿using ApiMVCApplication.Models;
using ApiMVCApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public HomeController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int page = 1)
        {
            int count = _usersRepository.TotalCount;
            var users = await _usersRepository.GetUsersAsync(count, page);

            return View(users);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var user = await _usersRepository.GetUserAsync(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            int countAdmin = _usersRepository.CountAdmin;
            ViewBag.CountAdmin = countAdmin < 1;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _usersRepository.CreateUser(user);
            await Task.Delay(1500);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _usersRepository.GetUserAsync(id);
            if (user != null)
                return View(user);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            await _usersRepository.UpdateUser(user);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _usersRepository.DeleteUser(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
