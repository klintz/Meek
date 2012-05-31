namespace Meek.Web.Mvc
{
    public class ViewConfigSource : IViewConfigSource
    {
        public ViewConfigSource(string xmlSource)
        {
            
        }

        internal ViewConfigSource()
        {
            
        }


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