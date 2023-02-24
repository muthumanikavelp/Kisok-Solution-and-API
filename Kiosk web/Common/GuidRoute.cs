using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Routing;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Kiosk_web.Common
{
    public class GuidRoute
    {
        private static readonly IRouter target;
        private readonly bool _isGuidRoute;
        public GuidRoute(string uri, object defaults)
        {
            _isGuidRoute = uri.Contains("guid");

            RouteValueDictionary DataTokens = new RouteValueDictionary();
        }
        public RouteContext HttpContext(HttpContext httpContext)
        {
            var routeData = HttpContext(httpContext);
            if (routeData == null)
                return null;

            if (!routeData.RouteData.Values.ContainsKey("guid") ||
            routeData.RouteData.Values["guid"].ToString() == "")
                routeData.RouteData.Values["guid"] = Guid.NewGuid().ToString("N");

            return routeData;
        }



        //    public override VirtualPathData VirtualPathData
        //(VirtualPathContext requestContext, RouteValueDictionary values)
        //    {
        //        return !_isGuidRoute ? null : base.OnVirtualPathGenerated(requestContext);
        //    }
    }

    public static class ControllerExtensionMethods
    {
        public static string GetGuid(this Controller controller)
        {
            return controller.RouteData.Values["guid"].ToString();
        }

        public static void SetGuidSession(this Controller controller, string name, object value)
        {
            controller.HttpContext.Session.SetString("controller.GetGuid() + _ + name", "value");
        }

        public static object GetGuidSession(this Controller controller, string name)
        {
            return controller.HttpContext.Session.GetString("controller.GetGuid() + _ + name");
        }        
    }
}