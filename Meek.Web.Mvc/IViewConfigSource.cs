namespace Meek.Web.Mvc
{
    public interface IViewConfigSource
    {
        IViewConfig GetViewConfig(string viewName);

        IPartialViewConfig GetPartialViewConfig(string partialViewName);

        IMasterConfig GetMasterConfig(string masterName);

        IViewConfigSource GetAreaConfig(string areaName);
    }
}