using Claims.Business.Models.Interfaces;

namespace Claims.Business.BLLs
{
    public interface IBaseBLL<TModel> where TModel : IBaseModel
    {
        TModel GetById(int id);
    }
}
