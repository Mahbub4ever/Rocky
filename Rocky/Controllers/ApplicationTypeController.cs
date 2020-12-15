using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objAplTypeList = _db.ApplicationType;
            return View(objAplTypeList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType objAplType)
        {
            if(ModelState.IsValid)
            {
                _db.ApplicationType.Add(objAplType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objAplType);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var objAplTypeId = _db.ApplicationType.Find(id);
            if (objAplTypeId == null)
            {
                return NotFound();
            }
            return View(objAplTypeId);
        }

        //POST - UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType objAplType)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(objAplType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objAplType);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var objAplTypeId = _db.ApplicationType.Find(id);
            if (objAplTypeId == null)
            {
                return NotFound();
            }
            return View(objAplTypeId);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var objAplTypeId = _db.ApplicationType.Find(id);
            if (objAplTypeId == null)
            {
                return NotFound();
            }
            else
            {
                _db.ApplicationType.Remove(objAplTypeId);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
    }
}
