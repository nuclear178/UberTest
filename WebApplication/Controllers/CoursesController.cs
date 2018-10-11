﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Application.Dtos;
using Application.Services;
using Domain;
using WebApplication.Forms.Courses;
using WebApplication.ViewModels.Courses;

namespace WebApplication.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUniversityAppService _universityService;

        public CoursesController(IUniversityAppService universityService)
        {
            _universityService = universityService;
        }

        // GET: Courses
        public ActionResult Index()
        {
            IEnumerable<CourseDto> models = _universityService.ListCourses();
            var viewModel = new CourseIndexViewModel(models);

            return View(viewModel);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                CourseDto model = _universityService.FindCourse(id.Value);
                var viewModel = new CourseDetailsViewModel(model);

                return View(viewModel);
            }
            catch (DomainException e)
            {
                Console.WriteLine(e); //Log
                return HttpNotFound();
            }
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCourseForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            try
            {
                _universityService.CreateCourse(form.ConvertToDto(), out var id);

                return RedirectToAction("Details", new {id});
            }
            catch (DomainException e)
            {
                Console.WriteLine(e); //Log
                throw new HttpException(503, e.Message);
            }
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                CourseDto model = _universityService.FindCourse(id.Value);
                EditCourseForm form = EditCourseForm.CreateFromModel(model);

                return View(form);
            }
            catch (DomainException e)
            {
                Console.WriteLine(e); //Log
                return HttpNotFound();
            }
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCourseForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            try
            {
                _universityService.EditCourse(form.ConvertToDto());

                return RedirectToAction("Index");
            }
            catch (DomainException e)
            {
                Console.WriteLine(e); //Log
                throw new HttpException(503, e.Message);
            }
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _universityService.DeleteCourse(id.Value);

            return RedirectToAction("Index");
        }
    }
}