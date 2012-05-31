using System;
using System.Globalization;
using System.Web.Mvc;

namespace Meek.Web.Mvc
{
    public class ExtendedRazorViewEngine : RazorViewEngine
    {
        private string _themesFolder = "~/Themes";

        #region ConfigSource
        private IViewConfigSource _configSource;
        protected virtual IViewConfigSource ConfigSource
        {
            get { _configSource = _configSource ?? new ViewConfigSource();
                return _configSource;
            }
            set { _configSource = value; }
        }

        public void SetViewConfigSource(IViewConfigSource source)
        {
            ConfigSource = source;
        }
        #endregion

        #region Theme
        public virtual string Theme { get; set; }
        #endregion

        #region ThemesFolder
        public virtual string ThemesFolder
        {
            get { return _themesFolder; }
            set { _themesFolder = value; }
        }
        #endregion

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

        #region FindView
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");

            if (string.IsNullOrEmpty(viewName))
                throw new ArgumentException("Value is required.", "viewName");

            
            var controllerName = controllerContext.RouteData.GetRequiredString("controller");
            
            string[] searchedViewLocations;

            var viewPath = GetViewPath(ViewLocationFormats, viewName, Theme,
                              controllerName, out searchedViewLocations);

            if(!string.IsNullOrEmpty(viewPath))
                return new ViewEngineResult(
                    (CreateView(controllerContext, viewPath, string.Empty)), this);

            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
        #endregion

        #region FindPartialView
        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");

            if (string.IsNullOrEmpty(partialViewName))
                throw new ArgumentException("Value is required.", "partialViewName");

            string[] searchedLocations;
            var controllerName = controllerContext.RouteData.GetRequiredString("controller");

            var partialViewPath = GetPartialPath(PartialViewLocationFormats, partialViewName, Theme,
                controllerName, out searchedLocations);

            if (!string.IsNullOrEmpty(partialViewPath))
                return new ViewEngineResult(
                    CreatePartialView(controllerContext, partialViewPath), this);


            return base.FindPartialView(controllerContext, partialViewName, useCache);
        }
        #endregion

        #region GetViewPath
        protected string GetViewPath(string[] locations, string viewName, string theme,
            string controllerName, out string[] searchedLocations)
        {
            var view = ConfigSource.GetViewConfig(viewName);
            searchedLocations = null;
            if (view == null || !view.Active)
            {
                searchedLocations = new string[locations.Length];

                for (var i = 0; i < locations.Length; i++)
                {
                    var path = string.Format(CultureInfo.InvariantCulture, locations[i],
                                         new object[] { viewName, controllerName });
                    if (VirtualPathProvider.FileExists(path))
                    {
                        searchedLocations = new string[0];
                        return path;
                    }
                    searchedLocations[i] = path;
                }
                return null;
            }

            return (view.Themed)
                ? string.Format("{0}/{1}/{2}", ThemesFolder, theme, view.File)
                : view.File;
        }
        #endregion

        #region GetPartialPath
        protected string GetPartialPath(string[] locations, string partialViewName, string theme,
            string controllerName, out string[] searchedLocations)
        {
            var partialView = ConfigSource.GetPartialViewConfig(partialViewName);
            searchedLocations = null;
            if (partialView == null || !partialView.Active)
            {

                searchedLocations = new string[locations.Length];

                for (var i = 0; i < locations.Length; i++)
                {
                    var path = string.Format(CultureInfo.InvariantCulture, locations[i],
                                         new object[] { partialViewName, controllerName });
                    if (VirtualPathProvider.FileExists(path))
                    {
                        searchedLocations = new string[0];
                        return path;
                    }
                    searchedLocations[i] = path;
                }
                return null;
            }
            return (partialView.Themed)
                ? string.Format("{0}/{1}/{2}", ThemesFolder, theme, partialView.File)
                : partialView.File;
        }
        #endregion
    }
}
