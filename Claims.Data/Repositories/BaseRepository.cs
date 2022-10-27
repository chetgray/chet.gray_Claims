using Claims.Data.DAL;
using Claims.Data.DTOs;

namespace Claims.Data.Repositories
{
    public abstract class BaseRepository<TDto> : IBaseRepository<TDto> where TDto : IBaseDTO
    {
        private readonly string _connectionString;
        private readonly IBaseDAL _dal;

        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
            _dal = new BaseDAL(_connectionString);
        }

        public abstract TDto GetById(int id);
    }
}
