namespace Meek.Web.Mvc
{
    public interface IViewConfig
    {
        string Name { get; }
        
        string File { get; }
        
        bool Themed { get; }

        bool Active { get; }
    }
}