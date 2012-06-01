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
        #endregion

        #region FindView
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");

            if (string.IsNullOrEmpty(viewName))
                throw new ArgumentException("Value is required.", "viewName");
            
            string[] searchedViewLocations;
            
            string customMasterName;

            var viewPath = GetViewPath(controllerContext, ViewLocationFormats, viewName, Theme,
                out searchedViewLocations, out customMasterName, useCache);

            var masterPath = string.Empty;
            if(!string.IsNullOrEmpty(customMasterName))
            {
                string[] searchedMasterLocations;
                masterPath = GetMasterPath(controllerContext, MasterLocationFormats, customMasterName, viewName, Theme,
                                           out searchedMasterLocations, useCache);
            }

            if (!string.IsNullOrEmpty(viewPath))
                return new ViewEngineResult(
                    (CreateView(controllerContext, viewPath, masterPath)), this);
            
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

            var partialViewPath = GetPartialPath(controllerContext, PartialViewLocationFormats, partialViewName, Theme,
                out searchedLocations, useCache);

            if (!string.IsNullOrEmpty(partialViewPath))
                return new ViewEngineResult(
                    CreatePartialView(controllerContext, partialViewPath), this);


            return base.FindPartialView(controllerContext, partialViewName, useCache);
        }
        #endregion

        #region GetViewPath
        protected string GetViewPath(ControllerContext controllerContext, string[] locations, string viewName, string theme,
            out string[] searchedLocations, out string masterName, bool useCache)
        {
            var area = controllerContext.RouteData.DataTokens.ContainsKey("area")
                           ? controllerContext.RouteData.DataTokens["area"].ToString()
                           : string.Empty;

            var config = ConfigSource.GetAreaConfig(area) ?? ConfigSource;

            var view = config.GetViewConfig(viewName);

            searchedLocations = null;
            masterName = null;

            if (view != null)
                masterName = view.Master;

            var controllerName = controllerContext.RouteData.GetRequiredString("controller");
            
            if(useCache)
            {
                var key = CreateCacheKey("view", area, viewName, controllerName, theme);
                var location = ViewLocationCache.GetViewLocation(controllerContext.HttpContext, key);
                if (!string.IsNullOrEmpty(location))
                    return location;
            }

            var path = string.Empty;
            if (view == null || !view.Active)
            {
                searchedLocations = new string[locations.Length];

                for (var i = 0; i < locations.Length; i++)
                {
                    path = string.Format(CultureInfo.InvariantCulture, locations[i],
                                         new object[] { viewName, controllerName });
                    if (VirtualPathProvider.FileExists(path))
                    {
                        searchedLocations = new string[0];

                        var key = CreateCacheKey("view", area, viewName, controllerName, theme);
                        ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, key, path);
                        return path;
                    }
                    searchedLocations[i] = path;
                }
                return path;
            }
            
            if(view.Themed)
            {
                path = string.Format("{0}/{1}/{2}", ThemesFolder, theme, view.File);
                if (VirtualPathProvider.FileExists(path))
                {
                    var key = CreateCacheKey("view", area, viewName, controllerName, theme);
                    ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, key, path);
                }
            }
            else
            {
                path = view.File;
                if (VirtualPathProvider.FileExists(path))
                {
                    var key = CreateCacheKey("view", area, viewName, controllerName, theme);
                    ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, key, path);
                }
            }
            return path;
        }
        #endregion

        #region GetPartialPath
        protected string GetPartialPath(ControllerContext controllerContext, string[] locations, string partialViewName, string theme,
            out string[] searchedLocations, bool useCache)
        {
            var area = controllerContext.RouteData.DataTokens.ContainsKey("area")
                           ? controllerContext.RouteData.DataTokens["area"].ToString()
                           : string.Empty;

            var config = ConfigSource.GetAreaConfig(area) ?? ConfigSource;

            var partialView = config.GetPartialViewConfig(partialViewName);
            searchedLocations = null;
            var controllerName = controllerContext.RouteData.GetRequiredString("controller");

            if (useCache)
            {
                var key = CreateCacheKey("partial", area, partialViewName, controllerName, theme);
                var location = ViewLocationCache.GetViewLocation(controllerContext.HttpContext, key);
                if (!string.IsNullOrEmpty(location))
                    return location;
            }

            var path = string.Empty;
            if (partialView == null || !partialView.Active)
            {
                searchedLocations = new string[locations.Length];

                for (var i = 0; i < locations.Length; i++)
                {
                    path = string.Format(CultureInfo.InvariantCulture, locations[i],
                                         new object[] { partialViewName, controllerName });
                    if (VirtualPathProvider.FileExists(path))
                    {
                        searchedLocations = new string[0];
                        var key = CreateCacheKey("partial", area, partialViewName, controllerName, theme);
                        ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, key, path);

                        return path;
                    }
                    searchedLocations[i] = path;
                }
                return path;
            }

            
            if(partialView.Themed)
            {
                path = string.Format("{0}/{1}/{2}", ThemesFolder, theme, partialView.File);
                if (VirtualPathProvider.FileExists(path))
                {
                    var key = CreateCacheKey("partial", area, partialViewName, controllerName, theme);
                    ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, key, path);
                }
            }
            else
            {
                path = partialView.File;
                if (VirtualPathProvider.FileExists(path))
                {
                    var key = CreateCacheKey("partial", area, partialViewName, controllerName, theme);
                    ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, key, path);
                }
            }
            return path;
        }
        #endregion

        #region GetMasterPath
        protected string GetMasterPath(ControllerContext controllerContext, string[] locations, string masterName, string viewName,
            string theme, out string[] searchedLocations, bool useCache)
        {
            var area = controllerContext.RouteData.DataTokens.ContainsKey("area")
                           ? controllerContext.RouteData.DataTokens["area"].ToString()
                           : string.Empty;
            
            var config = ConfigSource.GetAreaConfig(area) ?? ConfigSource;

            var master = config.GetMasterConfig(masterName);

            searchedLocations = null;
            var controllerName = controllerContext.RouteData.GetRequiredString("controller");

            if (useCache)
            {
                var key = CreateCacheKey("master", area, masterName, controllerName, theme);
                var location = ViewLocationCache.GetViewLocation(controllerContext.HttpContext, key);
                if (!string.IsNullOrEmpty(location))
                    return location;
            }

            var path = string.Empty;
            if (master == null || !master.Active)
            {
                searchedLocations = new string[locations.Length];

                for (var i = 0; i < locations.Length; i++)
                {
                    path = string.Format(CultureInfo.InvariantCulture, locations[i],
                                         new object[] { viewName, controllerName, theme });
                    if (VirtualPathProvider.FileExists(path))
                    {
                        searchedLocations = new string[0];
                        var key = CreateCacheKey("master", area, masterName, controllerName, theme);
                        ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, key, path);
                        return path;
                    }
                    searchedLocations[i] = path;
                }
                return path;
            }

            
            if (master.Themed)
            {
                path = string.Format("{0}/{1}/{2}", ThemesFolder, theme, master.File);
                if (VirtualPathProvider.FileExists(path))
                {
                    var key = CreateCacheKey("master", area, masterName, controllerName, theme);
                    ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, key, path);
                }
            }
            else
            {
                path = master.File;
                if (VirtualPathProvider.FileExists(path))
                {
                    var key = CreateCacheKey("master", area, masterName, controllerName, theme);
                    ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, key, path);
                }
            }
            return path;
        }
        #endregion

        #region CreateCacheKey
        private string CreateCacheKey(string prefix, string area, string name, string controllerName, string themeName)
        {
            return string.Format(CultureInfo.InvariantCulture,
                ":ViewCacheEntry:{0}:{1}:{2}:{3}:{4}:{5}",
                new object[] { GetType().AssemblyQualifiedName, prefix, area, name, controllerName, themeName });
        }
        #endregion
    }
}
