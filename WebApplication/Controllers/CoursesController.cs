using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Application.Dtos;
using Application.Interfaces;
using Domain.Exceptions;
using WebApplication.Forms.Courses;
using WebApplication.Models;
using WebApplication.Models.ActionFilters;
using WebApplication.ViewModels.Courses;

namespace WebApplication.Controllers
{
    public class CoursesController : Controller
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly IUniversityService _universityService;
        private readonly ITempStorage<EditCourseForm> _editFormStorage;

        public ActionResult Index()
        {
            IEnumerable<CourseDto> models = _universityService.ListCourses();
            var viewModel = new CourseIndexViewModel(models);

            return View(viewModel);
        }

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
                Logger.Error(e);
                return HttpNotFound();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

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
                Logger.Error(e);
                throw new HttpException(503, e.Message);
            }
        }

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
                Logger.Error(e);
                return HttpNotFound();
            }
        }

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
                Logger.Error(e);
                throw new HttpException(503, e.Message);
            }
        }

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
                Logger.Error(e);
                return HttpNotFound();
            }
        }

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

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _universityService.DeleteCourse(id.Value);

            return RedirectToAction("Index");
        }

        public CoursesController(IUniversityService universityService,
            ITempStorage<EditCourseForm> editFormStorage)
        {
            _universityService = universityService;
            _editFormStorage = editFormStorage;
        }
    }
}