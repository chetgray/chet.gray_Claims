using System.Configuration;

using Claims.Data.DAL;
using Claims.Data.DTOs;

namespace Claims.Data.Repositories
{
    public abstract class BaseRepository<TDto> : IBaseRepository<TDto> where TDto : IBaseDTO
    {
        protected readonly IBaseDAL _dal = new BaseDAL(
            ConfigurationManager.ConnectionStrings["ClaimsData"].ConnectionString
        );

        public abstract TDto Insert(TDto dto);
        public abstract TDto GetById(int id);
    }
}
