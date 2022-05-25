using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chat_App.Data;
using Chat_App.Models;
using Chat_App.services;

namespace Chat_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _service;

        public UsersController()
        {
            _service = new UserService();
        }

        [HttpGet]
        public IActionResult get()
        {
            return Json(_service.GetAll());
        }

        [HttpPost]
        public IActionResult LogIn([Bind("Id,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var t = _service.LogIn(user.Id, user.Password);
                if (!t)
                {
                    return NotFound();
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost("{method}")]
        public IActionResult Register(string method, [Bind("Id,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var t = _service.Register(user.Id, user.Password);
                if (!t)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            return BadRequest();
        }

        // GET: Users
        //public IActionResult Index()
        //{
        //    return Json(_service.GetAll());
        //}

        //// GET: Users/Details/5
        //public IActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = _service.Get((int)id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// GET: Users/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Users/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create([Bind("Id,Name,Password,Contacts")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _service.Create(user.Name, user.Password, user.Contacts);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Edit/5
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = _service.Get((int)id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, [Bind("Id,Name,Password,Contacts")] User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _service.Edit(id, user.Name, user.Password, user.Contacts);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            throw;
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Delete/5
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = _service.Get((int)id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    if (_service.Get((int)id) == null)
        //    {
        //        return Problem("Entity set 'Chat_AppContext.User'  is null.");
        //    }
        //    var user = _service.Get((int)id);
        //    if (user != null)
        //    {
        //        _service.Delete(id);
        //    }

        //    return RedirectToAction(nameof(Index));
        //}

    }
}
