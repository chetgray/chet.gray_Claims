using Claims.Data.DTOs;

namespace Claims.Data.Repositories
{
    public interface IBaseRepository<TDto> where TDto : IBaseDTO
    {
        TDto GetById(int id);
    }
}
