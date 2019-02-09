﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hackathon2019.Models;

namespace Hackathon2019.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
            List<Student> students = context.Students.Include(s => s.User).ToList();
            return View(students);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = context.Students.Include(s => s.User).Where(s => s.ID == id).FirstOrDefault();
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var existStudent = context.Students.Include(s => s.User).Where(s => s.ID == student.ID).FirstOrDefault();
            if (ModelState.IsValid)
            {
                existStudent.User.FirstMidName = student.User.FirstMidName;
                existStudent.User.LastName = student.User.FirstMidName;
                existStudent.Faculty = student.Faculty;
                existStudent.Institution = student.Institution;
                existStudent.InstitutionCourse = student.InstitutionCourse;
                existStudent.AboutMe = student.AboutMe;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Students");
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            var student = context.Students.Include(s => s.User).FirstOrDefault();
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteStudent(int ID)
        {
            var existStudent = context.Students.Include(s => s.User).Where(s => s.ID == ID).FirstOrDefault();
            if (existStudent != null) {
                context.Students.Remove(existStudent);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Students");
        }
    }
}