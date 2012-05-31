namespace Meek.Web.Mvc
{
    public interface IPartialViewConfig
    {
        string Name { get; }

        string File { get; }

        bool Themed { get; }

        bool Active { get; }
    }
}