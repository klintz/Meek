using Meek.Business;

namespace Meek.Presentation.Component
{
    public interface ILogicable
    {
        ILogic CurrentLogic { get; set; }    
    }
}