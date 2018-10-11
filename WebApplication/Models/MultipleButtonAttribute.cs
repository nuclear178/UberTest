using System;
using System.Reflection;
using System.Web.Mvc;

namespace WebApplication.Models
{
    //https://stackoverflow.com/questions/442704/how-do-you-handle-multiple-submit-buttons-in-asp-net-mvc-framework
    [AttributeUsage(AttributeTargets.Method)]
    public class MultipleButtonAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }
        public string Argument { get; set; }

        public override bool IsValidName(ControllerContext context, string actionName, MethodInfo methodInfo)
        {
            var keyValue = $"{Name}:{Argument}";
            ValueProviderResult value = context.Controller.ValueProvider.GetValue(keyValue);

            if (value == null)
            {
                return false;
            }

            context.RouteData.Values[Name] = Argument;

            return true;
        }
    }
}