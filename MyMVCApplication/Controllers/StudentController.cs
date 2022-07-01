using MyMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCApplication.Controllers
{
    public class StudentController : Controller
    {

        static IList<Student> studentList = new List<Student> {
                new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
        };
        
        // GET: Student
        public ActionResult Index()
        {
            //ViewBag
            //The ViewBag in ASP.NET MVC is used to transfer temporary data
            //(which is not included in the model) from the controller to the view. 
            ViewBag.StudentsNumber = studentList.Count();


            //ViewData
            IList<Student> studentList2 = new List<Student>();
            studentList2.Add(new Student() { StudentName = "Bill" });
            studentList2.Add(new Student() { StudentName = "Steve" });
            studentList2.Add(new Student() { StudentName = "Ram" });
            ViewData["students"] = studentList2;
            
            //To Add KeyValuePair
            ViewData.Add("Id", 1);
            ViewData.Add(new KeyValuePair<string, object>("Name", "Bill"));
            ViewData.Add(new KeyValuePair<string, object>("Age", 20));

            // fetch students from the DB using Entity Framework here
            return View(studentList.OrderBy(s => s.StudentId).ToList());
        }

        //this action will return View Edit
        public ActionResult Edit(int Id)
        {
            //here, get the student from the database in the real application

            //getting a student from collection for demo purpose
            var std = studentList.Where(s => s.StudentId == Id).FirstOrDefault();
            return View(std);


        }

        [HttpPost]
        public ActionResult Edit(Student std)
        {
            //update student in DB using EntityFramework in real-life application
            //update list by removing old student and adding updated student for demo purpose
            if (ModelState.IsValid)//checking model state
            {
                //check whether name is already exists in the database or not
               // Error Message : Validation Summary
                bool nameAlreadyExists = true; //Check in the database if name exists
                if (nameAlreadyExists)
                {
                    //adding error message to ModelState
                    ModelState.AddModelError("name", "Student Name Already Exists.");

                    return View(std);
                }

                var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
                studentList.Remove(student);
                studentList.Add(std);

                return RedirectToAction("Index");

            }
            return View(std);


        }
    }
}