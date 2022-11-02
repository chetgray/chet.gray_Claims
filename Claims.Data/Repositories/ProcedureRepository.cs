﻿using System;
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
                { "@procedureCode", dto.Code },
                { "@procedureName", dto.Name },
            };
            DataTable dataTable = _dal.ExecuteStoredProcedure(
                "dbo.spA_Procedure_Insert",
                parameters
            );
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            ProcedureDTO insertedDto = ConvertToDto(dataTable.Rows[0]);

            return insertedDto;
        }

        public override ProcedureDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ProcedureDTO GetByCode(string code)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@procedureCode", code }
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

        internal static ProcedureDTO ConvertToDto(DataRow row)
        {
            ProcedureDTO dto = new ProcedureDTO
            {
                Id = (int)row["ProcedureID"],
                Code = (string)row["ProcedureCode"],
                Name = (string)row["ProcedureName"],
            };

            return dto;
        }
    }
}
