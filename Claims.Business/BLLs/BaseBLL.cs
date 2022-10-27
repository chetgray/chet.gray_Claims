using Claims.Business.Models.Interfaces;

namespace Claims.Business.BLLs
{
    public abstract class BaseBLL<TModel> : IBaseBLL<TModel> where TModel : IBaseModel
    {
        private readonly string _connectionString;

        protected BaseBLL(string connectionString)
        {
            _connectionString =
                connectionString
                ?? throw new System.ArgumentNullException(nameof(connectionString));
        }

        public abstract TModel GetById(int id);
    }
}
