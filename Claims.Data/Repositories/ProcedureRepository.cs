using System;
using System.Collections.Generic;
using System.Data;

using Claims.Data.DTOs;

namespace Claims.Data.Repositories
{
    public class ProcedureRepository : BaseRepository<ProcedureDTO>
    {
        public ProcedureRepository(string connectionString) : base(connectionString) { }

        public override ProcedureDTO Insert(ProcedureDTO dto)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@code", dto.Code },
                { "@name", dto.Name },
            };

            DataTable dataTable = _dal.ExecuteStoredProcedure(
                "dbo.spA_Procedure_Insert",
                parameters
            );
            ProcedureDTO newDto = ConvertToDto(dataTable.Rows[0]);

            return newDto;
        }

        public override ProcedureDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ProcedureDTO GetByCode(string code)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@code", code }
            };

            DataTable dataTable = _dal.ExecuteStoredProcedure(
                "dbo.spA_Procedure_GetByCode",
                parameters
            );
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            ProcedureDTO dto = ConvertToDto(dataTable.Rows[0]);

            return dto;
        }

        private static List<ProcedureDTO> ConvertToDtoList(DataTable dataTable)
        {
            List<ProcedureDTO> dtos = new List<ProcedureDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                ProcedureDTO dto = ConvertToDto(row);
                dtos.Add(dto);
            }

            return dtos;
        }

        private static ProcedureDTO ConvertToDto(DataRow row)
        {
            ProcedureDTO dto = new ProcedureDTO
            {
                Id = (int)row["ProcedureID"],
                Code = (string)row["Code"],
                Name = (string)row["Name"],
            };

            return dto;
        }
    }
}
