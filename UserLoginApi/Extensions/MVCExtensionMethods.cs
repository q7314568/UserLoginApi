using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLoginApi.Extensions
{
    public static class MVCExtensionMethods
    {
        public static string BaseUrl(this IUrlHelper helper)
        {
            var url = string.Format("{0}://{1}", helper.ActionContext.HttpContext.Request.Scheme, helper.ActionContext.HttpContext.Request.Host.ToUriComponent());
            return url;
        }

        public static string FullURL(this IUrlHelper helper, string virtualPath)
        {
            var url = string.Format("{0}://{1}{2}", helper.ActionContext.HttpContext.Request.Scheme, helper.ActionContext.HttpContext.Request.Host.ToUriComponent(), helper.Content(virtualPath));

            return url;
        }
    }
}
