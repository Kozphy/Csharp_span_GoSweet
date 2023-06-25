using CRUDExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace CRUDExample.Controllers
{
    public class StudentsClassController : Controller
    {
        // private fields
        private readonly testContext _context;

        public StudentsClassController(testContext context) {
            _context = context;
        }

        // constructor
        [HttpGet]
        public IActionResult Index()
        {
            var listOfData = _context.student_tests.ToList();
            return View(listOfData);
        }

        // Create
        [HttpPost]
        public IActionResult Create([Bind("name", "student_id", "city", "chinese", "math")] student_test student_Test)
        {
            try
            {
                _context.student_tests.Add(student_Test);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction(nameof(Index));
        }


        // Get Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (_context.student_tests == null || id == null) {
                return NotFound();
            }

            var query = _context.student_tests.FirstOrDefault(x => x.id == id);

            if (query == null) {
                return NotFound();
            }
            
            return View(query);
        }

        // Post Edit 
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, [FromForm] [Bind("name", "student_id", "city", "chinese", "math")] student_test student_Test)
        {
            Console.WriteLine("id: {0}",id);
            Console.WriteLine("student_Test id: {0}", student_Test.id);
            Console.WriteLine("student_Test.student_id: {0}",student_Test.student_id);
            Console.WriteLine("student_Test.city: {0}",student_Test.city);
            Console.WriteLine("student_Test.chinese: {0}",student_Test.chinese);
            Console.WriteLine("student_Test.math:{0}",student_Test.math);
            try {
                var data = _context.student_tests.Where(x => x.id == id).FirstOrDefault();
                if (data != null) { 
                    data.name= student_Test.name;
                    data.student_id= student_Test.student_id;
                    data.city= student_Test.city;
                    data.chinese = student_Test.chinese;
                    data.math = student_Test.math;
                    _context.SaveChanges();
                }
            }catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        // delete page
        [HttpGet]
        public IActionResult Delete([FromRoute] int id) 
        {

            var query = _context.student_tests.Find(id);

            if (query == null) {
                return NotFound();
            }
            return View(query);
        }

        /// <summary>
        ///  delete
        /// </summary>
        /// <param name="student_Test"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete([FromForm] student_test student_Test) {
            Console.WriteLine("student_Test.id: {0}",student_Test.id);
            Console.WriteLine("student_Test.name: {0}",student_Test.name);
            Console.WriteLine("student_Test.student_id: {0}",student_Test.student_id);
            Console.WriteLine("student_Test.city: {0}",student_Test.city);
            Console.WriteLine("student_Test.math: {0}",student_Test.math);

            if (_context == null || student_Test.id == 0) {
                return NotFound();
            }

            try
            {
                _context.student_tests.Remove(student_Test);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        //public IActionResult Post(int id, student_test student_Test) 
        //{ 
        //    if(_context.student_tests)
        //    _context.student_tests.Update()
        //}



    }
}
