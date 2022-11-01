using Claims.Data.DTOs;

namespace Claims.Data.Repositories
{
    public interface IBaseRepository<TDto> where TDto : IBaseDTO
    {
        TDto Insert(TDto dto);
        TDto GetById(int id);
    }
}
