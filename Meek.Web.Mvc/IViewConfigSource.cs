namespace Meek.Web.Mvc
{
    public interface IViewConfigSource
    {
        IViewConfig GetViewConfig(string viewName);

        IPartialViewConfig GetPartialViewConfig(string partialViewName);
    }
}