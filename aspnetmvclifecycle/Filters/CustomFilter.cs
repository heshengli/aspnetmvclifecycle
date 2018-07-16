using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvclifecycle.Filters
{
    /// <summary>
    /// 自定义过滤器属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomFilter : ActionFilterAttribute
    {
        public bool EnableFilter { get;private set; }

        public CustomFilter()
        {
            EnableFilter = true;
        }

        public CustomFilter(bool enableFilter)
        {
            EnableFilter = enableFilter;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
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