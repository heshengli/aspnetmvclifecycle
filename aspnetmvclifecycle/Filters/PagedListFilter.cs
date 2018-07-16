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
    public class PagedListFilter : ActionFilterAttribute
    {
        public PagedListFilter()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("Action Executing Context is Null!");
            }
            //获取分页信息
            string pageIndex = filterContext.HttpContext.Request.Form["pageIndex"];
            string pageSize = filterContext.HttpContext.Request.Form["pageSize"];
            //默认设置：第一次加载页面
            if (string.IsNullOrWhiteSpace(pageIndex) || pageIndex == "0")
            {
                filterContext.Controller.ViewData["pageIndex"] = "1";
                filterContext.HttpContext.Request.Form["pageIndex"]= "1";
            }

            if (string.IsNullOrWhiteSpace(pageSize) || pageIndex == "0")
            {
                filterContext.Controller.ViewData["pageSize"] = "20";
                filterContext.HttpContext.Request.Form["pageSize"] = "20";
            }
        }
    }
}