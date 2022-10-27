using System.Collections.Generic;
using System.Data;

namespace Claims.Data.DAL
{
    public interface IBaseDAL
    {
        DataTable ExecuteStoredProcedure(
            string storedProcedureName,
            Dictionary<string, object> parameters
        );
    }
}
