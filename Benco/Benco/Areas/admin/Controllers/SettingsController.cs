using Benco.Data;
using Benco.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benco.Areas.admin.Controllers
{
    [Area("admin")]
    public class SettingsController : Controller
    {
        private readonly AppDbContext _context;

        public SettingsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Settings.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Settings model)
        {
            _context.Settings.Add(model);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Update(int id)
        {
            return View(_context.Settings.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Settings model)
        {

            if (ModelState.IsValid)
            {
                _context.Settings.Update(model);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "bos saxlama");
                return View(model);
            }
            
        }
         
        public IActionResult Delete(int? id)
        {

            if (id==null)
            {
                return NotFound();
            }
            Settings settings = _context.Settings.Find(id);


            if (settings==null)
            {
                return NotFound();
            }
            _context.Settings.Remove(settings);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


    }
}
