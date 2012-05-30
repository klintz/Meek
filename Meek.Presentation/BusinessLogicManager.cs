using Meek.Business;

namespace Meek.Presentation
{
    public sealed class BusinessLogicManager
    {
        public static IBusinessFactory BusinessFactory { get; private set; }

        public static void SetBusinessFactory(IBusinessFactory factory)
        {
            BusinessFactory = factory;
        }
         
    }
}