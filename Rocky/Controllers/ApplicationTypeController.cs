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

        public IActionResult Create()
        {
            return View();
        }

        //GET - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType objAplType)
        {
            _db.ApplicationType.Add(objAplType);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
