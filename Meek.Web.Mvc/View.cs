using System.Web.Mvc;

namespace Meek.Web.Mvc
{
    public abstract class View : WebViewPage
    {
    }

    public abstract class View<TModel> : WebViewPage<TModel>
    {
    }
}
