using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvclifecycle.Filters
{
    public class CustomActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("Action Executing Context is Null!");
            }

            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            //todo:自定义功能

            #region 1 自动回传请求参数

            var forms = filterContext.HttpContext.Request.Form;
            if (forms != null && forms.Count > 0)
            {
                foreach (string key in forms.AllKeys)
                {
                    filterContext.Controller.ViewData[key] = forms[key];
                }
            }

            var queryStrings = filterContext.HttpContext.Request.QueryString;
            if (queryStrings != null && queryStrings.Count > 0)
            {
                foreach (string key in queryStrings.AllKeys)
                {
                    filterContext.Controller.ViewData[key] = queryStrings[key];
                }
            }
            #endregion
        }
    }
}