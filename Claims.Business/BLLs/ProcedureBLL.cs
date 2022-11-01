using System;

using Claims.Business.Models;
using Claims.Business.Models.Interfaces;
using Claims.Data.DTOs;
using Claims.Data.Repositories;

namespace Claims.Business.BLLs
{
    public class ProcedureBLL : BaseBLL<IProcedureModel>
    {
        private readonly ProcedureRepository _repository;

        public ProcedureBLL(string connectionString) : base(connectionString)
        {
            _repository = new ProcedureRepository(_connectionString);
        }

        public override IProcedureModel Insert(IProcedureModel model)
        {
            ProcedureDTO dto = ConvertToDto(model);

            IProcedureModel insertedModel = ConvertToModel(_repository.Insert(dto));

            return insertedModel;
        }

        public override IProcedureModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        private static IProcedureModel ConvertToModel(ProcedureDTO dto)
        {
            if (dto is null)
            {
                return null;
            }
            IProcedureModel model = new ProcedureModel
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name
            };

            return model;
        }

        private static ProcedureDTO ConvertToDto(IProcedureModel model)
        {
            if (model is null)
            {
                return null;
            }
            ProcedureDTO dto = new ProcedureDTO
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name
            };

            return dto;
        }
    }
}
