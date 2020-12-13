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

        public IActionResult Create()
        {
            return View();
        }

        //GET - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category objCat)
        {
            _db.Category.Add(objCat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
