﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Chat_App.Data;
//using Chat_App.Models;
//using Chat_App.services;

//namespace Chat_App.Controllers
//{
//    public class regularMessagesController : Controller
//    {
//        private readonly IMessageService _service;

//        public regularMessagesController(Chat_AppContext context)
//        {
//            _service = new MessageService();
//        }

//        // GET: Users
//        public IActionResult Index()
//        {
//            return View(_service.GetAll());
//        }

//        // GET: Users/Details/5
//        public IActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var message = _service.Get((int)id);

//            if (message == null)
//            {
//                return NotFound();
//            }

//            return View(message);
//        }
       
//        public int Create([Bind("Content")] Message message)
//        {
//                _service.Create(message.Content);
//                return message.Id;
//        }

//        // GET: Users/Delete/5
//        public IActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var message = _service.Get((int)id);

//            if (message == null)
//            {
//                return NotFound();
//            }

//            return View(message);
//        }

//        // POST: Users/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            if (_service.Get((int)id) == null)
//            {
//                return Problem("Entity set 'Chat_AppContext.User'  is null.");
//            }
//            var user = _service.Get((int)id);
//            if (user != null)
//            {
//                _service.Delete(id);
//            }

//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
