using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvclifecycle.Filters
{
    /// <summary>
    /// 授权
    /// </summary>
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.Result == null)
            {

            }
        }
    }
}