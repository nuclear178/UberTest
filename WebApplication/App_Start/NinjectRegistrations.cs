using System.Web.Mvc;
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
            //...

            //Application services
            //...

            //Domain services
            //...
        }
    }
}