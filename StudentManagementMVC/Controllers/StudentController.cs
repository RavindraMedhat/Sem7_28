
using Newtonsoft.Json;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> students = new List<Student>();
        private static int last_id = 0;

        public StudentController()
        {
            if (students.Count() == 0)
            {

                students.Add(new Student { id = 1, name = "ravindrasinh", age = 22 });
                students.Add(new Student { id = 2, name = "rajvi", age = 22 });
                students.Add(new Student { id = 3, name = "vivek", age = 24 });
                students.Add(new Student { id = 4, name = "rohan", age = 21 });

                last_id = (from s in students
                           select s.id).Max();
            }
        }
        // GET: StudentController
        public ActionResult Index(string studentsJson)
        {
         
            if (studentsJson != null)
            {
                List<Student> studentsData = JsonConvert.DeserializeObject<List<Student>>(studentsJson);
                return View(studentsData);
            }
            else
                return View(students.ToList());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            Student std = students.Where(s => s.id == id).FirstOrDefault();
            return View(std);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student collection)
        {
            try
            {
                collection.id = ++last_id;
                students.Add(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            Student std = students.FirstOrDefault(s => s.id == id);
            return View(std);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student collection)
        {
            try
            {
                Student std = students.FirstOrDefault(s => s.id == id);

                std.name = collection.name;
                std.age = collection.age;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            Student std = students.Where(s => s.id == id).FirstOrDefault();
            return View(std);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student collection)
        {
            try
            {
                Student std = students.Where(s => s.id == id).FirstOrDefault();
                students.Remove(std);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Search()
        {
            return View(students);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string SearchName, int? SearchAge)
        {
            try
            {
                //Search = "r";
                // == & .= different
                List<Student> studentsData;
                if (SearchName != null)
                {
                    studentsData = (from s in students
                                    where s.name.ToUpper().Contains(SearchName.ToUpper())
                                    select s).ToList();
                }
                else
                {
                    studentsData = (from s in students
                                    where s.age == SearchAge
                                    select s).ToList();
                }
                return View(studentsData);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchByObject()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchByObject(Student SearchObject)
        {
            try
            {
                List<Student> studentsData;
                //Search = "r";
                // == & .= different
                if (SearchObject.name != null && SearchObject.name != "")
                {
                    studentsData = (from s in students
                                    where s.name.ToUpper().Contains(SearchObject.name.ToUpper())
                                    select s).ToList();
                }
                else
                {
                    studentsData = (from s in students
                                    where s.age == SearchObject.age
                                    select s).ToList();
                }
                string studentsJson = JsonConvert.SerializeObject(studentsData);


                return RedirectToAction(nameof(Index), new { studentsJson });
            }
            catch
            {
                return View();
            }
        }
    }
}
