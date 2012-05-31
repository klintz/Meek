using System;
using System.Web.Mvc;

namespace Meek.Web.Mvc
{
    public class ExtendedRazorViewEngine : RazorViewEngine
    {

        #region Constructor
        public ExtendedRazorViewEngine()
        {
            //Areas
            AreaViewLocationFormats = new[] {
                "~/Areas/{2}/{1}/{0}.cshtml",
                "~/Areas/{2}/{1}/{0}.vbhtml",
                "~/Areas/{2}/Shared/{0}.cshtml",
                "~/Areas/{2}/Shared/{0}.vbhtml"
            };

            AreaMasterLocationFormats = new[] {
                "~/Areas/{2}/{1}/{0}.cshtml",
                "~/Areas/{2}/{1}/{0}.vbhtml",
                "~/Areas/{2}/Shared/{0}.cshtml",
                "~/Areas/{2}/Shared/{0}.vbhtml"
            };

            AreaPartialViewLocationFormats = new[] {
                "~/Areas/{2}/{1}/{0}.cshtml",
                "~/Areas/{2}/{1}/{0}.vbhtml",
                "~/Areas/{2}/Shared/{0}.cshtml",
                "~/Areas/{2}/Shared/{0}.vbhtml"
            };

            //Root
            ViewLocationFormats = new[] {
                "~/{0}.cshtml",
                "~/{0}.vbhtml",
                "~/{1}/{0}.cshtml",
                "~/{1}/{0}.vbhtml"
            };

            PartialViewLocationFormats = new[]{
                "~/{0}.cshtml",
                "~/{0}.vbhtml",
                "~/{1}/{0}.cshtml",
                "~/{1}/{0}.vbhtml",
                "~/Controls/{0}.cshtml",
                "~/Controls/{0}.vbhtml"
            };

            MasterLocationFormats = new[] {
                "~/{0}.cshtml",
                "~/{0}.vbhtml",
                "~/{1}/{0}.cshtml",
                "~/{1}/{0}.vbhtml",
                "~/Shared/{0}.cshtml",
                "~/Shared/{0}.vbhtml"
            };
        }
        #endregion

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");

            if (string.IsNullOrEmpty(viewName))
                throw new ArgumentException("Value is required.", "viewName");

            var controllerName = controllerContext.RouteData.GetRequiredString("controller");

            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");

            if (string.IsNullOrEmpty(partialViewName))
                throw new ArgumentException("Value is required.", "partialViewName");

            return base.FindPartialView(controllerContext, partialViewName, useCache);
        }
    }
}
