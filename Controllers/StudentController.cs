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
        
        public IActionResult Edit(int id)
            {
            var student = db.students.Find(id);

            if (student == null)
                {
                return NotFound();
                }

            return View(student);
            }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentModel s)
            {
            if (ModelState.IsValid)
                {
                db.students.Update(s);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Create", new { id = s.student_id });
                }

            return View(s);
            }

        // GET: Student/Delete/5
        public IActionResult Delete(int id)
            {
            var student = db.students.Find(id);

            if (student == null)
                {
                return NotFound();
                }

            return View(student);
            }

        // POST: Student/Delete/5
[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
            {
            var student = db.students.Find(id);

            if (student != null)
                {
                db.students.Remove(student);
                db.SaveChanges();
                }

            return RedirectToAction("Create");
            }
        }
    }
