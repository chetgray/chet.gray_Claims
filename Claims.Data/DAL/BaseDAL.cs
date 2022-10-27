using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Claims.Data.DAL
{
    internal class BaseDAL : IBaseDAL
    {
        private string _connectionString;

        internal BaseDAL(string connectionString)
        {
            _connectionString =
                connectionString
                ?? throw new System.ArgumentNullException(nameof(connectionString));
        }

        public DataTable ExecuteStoredProcedure(
            string storedProcedureName,
            Dictionary<string, object> parameters
        )
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
    }
}
