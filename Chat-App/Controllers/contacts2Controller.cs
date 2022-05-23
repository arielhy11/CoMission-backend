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
    public class Contacts2Controller : Controller
    {
        private readonly IContactService _service;

        public Contacts2Controller(Chat_AppContext context)
        {
            _service = new ContactService();
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            return Json(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var contact = _service.Get((int)id);
            if (contact == null)
                return NotFound();
            return Json(contact);
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Name,NickName,Messages,User")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _service.Create(contact.Name, contact.NickName, contact.Messages, contact.User);
                return Created(String.Format("/api/contact/{0}", contact.Id), contact);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [Bind("Id,Name,NickName,Messages,User")] Contact contact)
        {
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
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_service.Get((int)id) == null)
            {
                return NotFound();
            }
            var contact = _service.Get((int)id);
            if (contact != null)
            {
                _service.Delete(id);
            }
            return NoContent();
        }
    }
}
