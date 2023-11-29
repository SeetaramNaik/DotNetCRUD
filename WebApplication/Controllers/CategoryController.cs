using Application.DataAccess;
using Application.DataAccess.Repository.iRepository;
using Application.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.GetAll();
            return View(categoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
           
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //var category = _db.Categories.Find(id);
            var category = _db.GetFirstOrDefualt(c=>c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var category = _db.Categories.Find(id);
            var category = _db.GetFirstOrDefualt(c=>c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Remove(obj);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(obj);

        }


    }
}
