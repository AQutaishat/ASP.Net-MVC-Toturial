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
        static List<Student> studentList = new List<Student>{
                            new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                            new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                            new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                            new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                            new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                            new Student() { StudentId = 6, StudentName = "Chris" , Age = 17 } ,
                            new Student() { StudentId = 7, StudentName = "Rob" , Age = 19 }
                        };

        public ActionResult Index()
        {
            return View(studentList);
        }

        public ActionResult Edit(int? Id)
        {
            Student student = new Student();
            if (Id != null)
            {
                student = studentList.Where(st => st.StudentId == Id).FirstOrDefault();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (student.StudentId != 0)
            {
                var IndexOfStuden = studentList.FindIndex(x => x.StudentId == student.StudentId);
                studentList.RemoveAt(IndexOfStuden);
                studentList.Insert(IndexOfStuden, student);
            }
            else
            {
                student.StudentId = studentList.Max(x=>x.StudentId) + 1;
                studentList.Add(student);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            studentList.RemoveAll(x=> x.StudentId == student.StudentId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Student student = studentList.Where(st => st.StudentId == Id).FirstOrDefault();
            
            return View(student);
        }
    }
}