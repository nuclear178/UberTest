using System;
using System.Net;
using System.Web.Mvc;
using Application.Dtos;
using Application.Services;
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
            var viewModel = new CourseIndexViewModel
            {
                Courses = _universityService.ListCourses()
            };

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
                var viewModel = new CourseDetailsViewModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    PublicationDate = model.PublicationDate
                };

                return View(viewModel);
            }
            catch (ApplicationException e)
            {
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

            var input = new CreateCourseDto
            {
                Title = form.Title,
                Description = form.Description,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };
            _universityService.CreateCourse(input, out var id);
            return RedirectToAction("Details", new {id});
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CourseDto model = _universityService.FindCourse(id.Value);
            var form = new EditCourseForm
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description
            };

            return View(form);
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

            var input = new EditCourseDto
            {
                Title = form.Title,
                Description = form.Description,
            };
            _universityService.EditCourse(input);

            return RedirectToAction("Index");
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