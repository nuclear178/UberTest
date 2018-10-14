using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Application;
using Application.Dtos;
using Application.Services;
using Domain;
using WebApplication.Forms.Courses;
using WebApplication.Models;
using WebApplication.Models.ActionFilters;
using WebApplication.ViewModels.Courses;

namespace WebApplication.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUniversityAppService _universityService;
        private readonly ITempStorage<EditCourseForm> _editFormStorage;

        public CoursesController(IUniversityAppService universityService,
            ITempStorage<EditCourseForm> editFormStorage)
        {
            _universityService = universityService;
            _editFormStorage = editFormStorage;
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
                EditCourseForm form = _editFormStorage.Contains(id.Value)
                    ? _editFormStorage.Get(id.Value)
                    : EditCourseForm.CreateFromModel(
                        _universityService.FindCourse(id.Value)
                    );

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
        [HttpParamAction]
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
                _editFormStorage.Clear(form.Id);

                return RedirectToAction("Index");
            }
            catch (DomainException e)
            {
                Console.WriteLine(e); //Log
                throw new HttpException(503, e.Message);
            }
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [HttpParamAction]
        public ActionResult PreviewEdit(EditCourseForm form)
        {
            _editFormStorage.Set(form.Id, form);

            try
            {
                CourseDto model = _universityService.FindCourse(form.Id);
                model.Title = form.Title;
                model.Description = form.Description;

                var viewModel = new CourseDetailsViewModel(model);

                return View("PreviewEdit", viewModel);
            }
            catch (DomainException e)
            {
                Console.WriteLine(e); //Log
                return HttpNotFound();
            }
        }

        // GET: Courses/ConfirmEdit/5
        public ActionResult ConfirmEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return _editFormStorage.Contains(id.Value)
                ? Edit(_editFormStorage.Get(id.Value))
                : new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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