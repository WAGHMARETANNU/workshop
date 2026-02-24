using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.DBFOLDER;
using workshop.Models;

namespace workshop.Controllers
    {
    public class StudentController : Controller
        {
        private STUDENTDB db;

        public StudentController(STUDENTDB s)
            {
            db = s;
            }
        [HttpGet]
        public IActionResult add()
            {
            return View();
            }
        [HttpPost]
        public IActionResult add(StudentModel s)
            {
            if (ModelState.IsValid)
                {
                db.students.Add(s);
                db.SaveChanges();

                return RedirectToAction("Add");

                }
            return View();
            }
        [HttpGet]
        public async Task<IActionResult> Create()
            {
            var students = await db.students.ToListAsync();

            return View(students);

            }
        }
    }
