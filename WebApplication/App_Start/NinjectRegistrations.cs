using System.Web.Mvc;
using Application;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Ninject.Modules;
using WebApplication.Forms.Courses;
using WebApplication.Models;

namespace WebApplication
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //UI
            Unbind<ModelValidatorProvider>();
            Bind<ITempStorage<EditCourseForm>>().To<SessionEditCourseFormTempStorage>();

            //Data layer
            Bind<UniversityContext>().To<UniversityContext>();
            Bind<ICourseRepository>().To<EfCourseRepository>();

            //Application services
            Bind<IUniversityService>().To<UniversityService>();

            //Domain services
            Bind<ISerialNumberGenerator>().To<SerialNumberGenerator>();
        }
    }
}