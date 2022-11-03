using System.Collections.Generic;
using System.Data;

using Claims.Data.DTOs;

namespace Claims.Data.Repositories
{
    public class HospitalRepository : BaseRepository
    {
        public HospitalDTO Insert(HospitalDTO dto)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@hospitalName", dto.Name },
                { "@hospitalStreet", dto.Street },
                { "@hospitalCity", dto.City },
                { "@hospitalState", dto.State },
                { "@hospitalZip", dto.Zip },
            };
            DataTable dataTable = _dal.ExecuteStoredProcedure(
                "dbo.spA_Hospital_Insert",
                parameters
            );
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            HospitalDTO insertedDto = ConvertToDto(dataTable.Rows[0]);

            return insertedDto;
        }

        public HospitalDTO GetByName(string name)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@hospitalName", name },
            };
            DataTable dataTable = _dal.ExecuteStoredProcedure(
                "dbo.spA_Hospital_GetByName",
                parameters
            );
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            HospitalDTO dto = ConvertToDto(dataTable.Rows[0]);

            return dto;
        }

        internal static HospitalDTO ConvertToDto(DataRow row)
        {
            HospitalDTO dto = new HospitalDTO
            {
                Id = (int)row["HospitalId"],
                Name = (string)row["HospitalName"],
                Street = (string)row["HospitalStreet"],
                City = (string)row["HospitalCity"],
                State = (string)row["HospitalState"],
                Zip = (string)row["HospitalZip"],
            };

            return dto;
        }
    }
}
