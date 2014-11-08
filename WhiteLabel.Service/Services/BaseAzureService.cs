using WhiteLabel.Data;
using WhiteLabel.Data.Azure;

namespace WhiteLabel.Business.Services
{
    public interface IAzureRepository<T> : IRepository<T> where T : class
    {
       T GetById(string partitionkey, string rowKey);
    }
    public abstract class BaseAzureService<T> : BaseService<T> where T: HCTableEntity
    {
        private readonly IAzureRepository<T> _repository;
        protected BaseAzureService(IAzureRepository<T> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public override bool Update(T entity)
        {
            if (IsValid(entity))
            {
                BeforeUpdate(entity);
                var itemExists = _repository.GetById(entity.PartitionKey, entity.RowKey) != null;
                if (itemExists)
                {
                    return _repository.Update(entity);
                }
            }

            return false;
        }
    }
}
