using System.Web.Mvc;
using Application.Services;
using Domain.Services;
using Domain.Services.Repositories;
using Infrastructure.Domain;
using Infrastructure.Persistence.EntityFramework;
using Infrastructure.Persistence.EntityFramework.Repositories;
using Ninject.Modules;

namespace WebApplication
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //UI
            Unbind<ModelValidatorProvider>();

            //Data layer
            Bind<UniversityContext>().To<UniversityContext>();
            Bind<ICourseRepository>().To<EfCourseRepository>();

            //Application services
            Bind<IUniversityAppService>().To<UniversityAppService>();

            //Domain services
            Bind<ISerialNumberGenerator>().To<SerialNumberGenerator>();
        }
    }
}