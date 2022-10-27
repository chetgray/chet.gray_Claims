using System.Collections.Generic;
using System.Data;

namespace Claims.Data.DAL
{
    internal interface IBaseDAL
    {
        DataTable ExecuteStoredProcedure(
            string storedProcedureName,
            Dictionary<string, object> parameters
        );
    }
}
