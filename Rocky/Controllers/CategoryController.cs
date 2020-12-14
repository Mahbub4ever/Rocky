using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections.Generic;


namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category objCat)
        {
            if(ModelState.IsValid)
            {
                _db.Category.Add(objCat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objCat);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if(id== null || id== 0)
            {
                return NotFound();
            }
            var objCatId = _db.Category.Find(id);
            if(objCatId == null)
            {
                return NotFound();
            }
            return View(objCatId);
        }

        //POST - UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category objCat)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(objCat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objCat);
        }


        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var objCatId = _db.Category.Find(id);
            if (objCatId == null)
            {
                return NotFound();
            }
            return View(objCatId);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var objCatId = _db.Category.Find(id);
            if(objCatId == null)
            {
                return NotFound();
            }
            _db.Category.Remove(objCatId);
            _db.SaveChanges();
            return RedirectToAction("Index");            
        }
    }
}
