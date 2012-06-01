namespace Meek.Web.Mvc
{
    public interface IMasterConfig
    {
        string Name { get; }

        string File { get; }

        bool Themed { get; }

        bool Active { get; }
    }
}