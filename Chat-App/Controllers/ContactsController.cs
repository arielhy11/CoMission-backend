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
    public class ContactsController : Controller
    {
        private readonly IContactService _service;

        public ContactsController(Chat_AppContext context)
        {
            _service = new ContactService();
        }

        // GET: Users
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _service.Get((int)id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,NickName,Messages,User")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _service.Create(contact.Name, contact.NickName, contact.Messages, contact.User);
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _service.Get((int)id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,NickName,Messages,User")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Edit(id, contact.Name, contact.NickName, contact.Messages, contact.User);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _service.Get((int)id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_service.Get((int)id) == null)
            {
                return Problem("Entity set 'Chat_AppContext.User'  is null.");
            }
            var contact = _service.Get((int)id);
            if (contact != null)
            {
                _service.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
