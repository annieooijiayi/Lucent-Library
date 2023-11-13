using Lucent_Library.Data;
using Lucent_Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lucent_Library.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDBContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(ApplicationDBContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> obj = _db.Books;
            return View(obj);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book obj)
        {
            if (ModelState.IsValid)
            {
                string directory = "uploads/cover/";
                directory += Guid.NewGuid().ToString() + "_" + obj.CoverPicture.FileName;
                obj.CoverPicturePath = "/" + directory;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, directory);

                obj.CoverPicture.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                _db.Books.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        //post
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditBook(Book obj)
        {
            if (ModelState.IsValid)
            {
                string directory = "uploads/cover/";
                directory += Guid.NewGuid().ToString() + "_" + obj.CoverPicture.FileName;
                obj.CoverPicturePath = "/" + directory;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, directory);

                obj.CoverPicture.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                _db.Books.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
