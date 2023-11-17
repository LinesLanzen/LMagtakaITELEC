using Microsoft.AspNetCore.Mvc;
using LMagtakaITELEC.Models;
using System;
using System.Collections.Generic;

namespace LMagtakaITELEC.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                GPA = 3.8,
                Course = "Computer Science",
                AdmissionDate = DateTime.Now,
                Email = "john@example.com"
            },
            new Student
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                GPA = 3.5,
                Course = "Mathematics",
                AdmissionDate = DateTime.Now.AddMonths(-6),
                Email = "jane@example.com"
            },
            new Student
            {
                Id = 3,
                FirstName = "Alice",
                LastName = "Johnson",
                GPA = 3.2,
                Course = "Physics",
                AdmissionDate = DateTime.Now.AddMonths(-12),
                Email = "alice@example.com"
            },
            new Student
            {
                Id = 4,
                FirstName = "Bob",
                LastName = "Williams",
                GPA = 3.9,
                Course = "Biology",
                AdmissionDate = DateTime.Now.AddMonths(-3),
                Email = "bob@example.com"
            },
           
        };

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = students.Find(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var index = students.FindIndex(s => s.Id == student.Id);
                if (index == -1)
                {
                    return NotFound();
                }

                students[index] = student;
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult ShowDetails(int id)
        {
            var student = students.Find(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
