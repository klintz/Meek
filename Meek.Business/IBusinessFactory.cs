namespace Meek.Business
{
    public interface IBusinessFactory
    {
        TLogic CreateBusinessLogic<TLogic>()
            where TLogic : ILogic;

        TLogic CreateBusinessLogic<TLogic>(TLogic defaultLogic)
            where TLogic : ILogic;
    }
}
