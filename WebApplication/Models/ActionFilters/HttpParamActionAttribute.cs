using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.ActionFilters
{
    public class HttpParamActionAttribute : ActionNameSelectorAttribute
    {
        public override bool IsValidName(ControllerContext context, string actionName, MethodInfo methodInfo)
        {
            if (actionName.Equals(methodInfo.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            if (!actionName.Equals("Action", StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            HttpRequestBase request = context.RequestContext.HttpContext.Request;
            return request[methodInfo.Name] != null;
        }
    }
}