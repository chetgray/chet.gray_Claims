using System.Configuration;

using Claims.Data.DAL;

namespace Claims.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IBaseDAL _dal = new BaseDAL(
            ConfigurationManager.ConnectionStrings["ClaimsData"].ConnectionString
        );
    }
}
