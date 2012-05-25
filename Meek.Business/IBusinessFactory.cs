using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
