using System.ServiceModel;

namespace Meek.Data
{
    [ServiceContract]
    public interface IDataSession
    {
        IDataProvider Provider { get; set; }

        [OperationContract(Name = "BeginTransaction")]
        void BeginTransaction();

        [OperationContract(Name = "CommitTransaction")]
        void CommitTransaction();

        [OperationContract(Name = "RollbackTransaction")]
        void RollbackTransaction();

    }
}
