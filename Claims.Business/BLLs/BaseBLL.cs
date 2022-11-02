using Claims.Business.Models.Interfaces;

namespace Claims.Business.BLLs
{
    public abstract class BaseBLL<TModel> : IBaseBLL<TModel> where TModel : IBaseModel
    {
        public abstract TModel Insert(TModel model);
        public abstract TModel GetById(int id);
    }
}
