using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;

namespace aspnetmvclifecycle.Filters
{
    /// <summary>
    /// 身份认证
    /// </summary>
    public class CustomAuthenticationFilter : IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.Result == null)
            {
            }
            //todo:操作http请求上下文
            var queryStrings = filterContext.RequestContext.HttpContext.Request.QueryString;
            if (queryStrings != null && queryStrings.Count > 0)
            {
                foreach (var queryitem in queryStrings)
                {

                }
            }
            var forms = filterContext.RequestContext.HttpContext.Request.Form;
            if (forms != null && forms.Count > 0)
            {
                foreach (var formitem in forms)
                {

                }
            }

        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null)
            {
                return;
            }
        }
    }
}