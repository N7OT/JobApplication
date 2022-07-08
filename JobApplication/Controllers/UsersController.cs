using System.Linq;
using JobApplication.Data;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplication.Data.Services;
using JobApplication.Models;

namespace JobApplication.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }


        //Get: Users/Create
        public IActionResult Create()
		{
            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,LastName,Phone,Email")]User user)
		{
			if (!ModelState.IsValid)
			{
                return View(user);
			}
            await _service.AddAsync(user);
            return RedirectToAction(nameof(Index));
		}

        //Get: User/Details/1
        public async Task<IActionResult> Details(int id)
		{
            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null) return View("NotFound");
            return View(userDetails);
		}

        //Get: Users/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null) return View("NotFound");
            return View(userDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Name,LastName,Phone,Email")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            await _service.UpdateAsync(id,user);
            return RedirectToAction(nameof(Index));
        }

        //Get: Users/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null) return View("NotFound");
            return View(userDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
