namespace Meek.Web.Mvc
{
    public class ViewConfigSource : IViewConfigSource
    {
        public IViewConfig GetViewConfig(string viewName)
        {
            return default(IViewConfig);
        }

        public IPartialViewConfig GetPartialViewConfig(string partialViewName)
        {
            return default(IPartialViewConfig);
        }
    }
}