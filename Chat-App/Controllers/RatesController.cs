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
    public class RatesController : Controller
    {
        private IRateService service;

        public RatesController(Chat_AppContext context)
        {
            service = new RateService();
        }

        // GET: Rates
        public IActionResult Index()
        {
              return View(service.GetAll());
        }

        // GET: Rates/Details/5
        public IActionResult Details(int id)
        {
            return View(service.Get(id));
        }

        // GET: Rates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string userName, string description, int value)
        {
            service.Create(userName, description, value);
           
            return RedirectToAction(nameof(Index));
        }

        // GET: Rates/Edit/5
        public IActionResult Edit(int id)
        {
            return View(service.Get(id));
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string userName, string description, int value)
        {
            service.Edit(id, userName, description, value);

            return RedirectToAction(nameof(Index));
           
        }

        // GET: Rates/Delete/5
        public IActionResult Delete(int id)
        {
            return View(service.Get(id));
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
