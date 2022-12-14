using Claims.Business.Models;
using Claims.Business.Models.Interfaces;
using Claims.Data.DTOs;
using Claims.Data.Repositories;

namespace Claims.Business.BLLs
{
    public class ProcedureBLL
    {
        private readonly ProcedureRepository _repository = new ProcedureRepository();

        public IProcedureModel Insert(IProcedureModel model)
        {
            ProcedureDTO dto = ConvertToDto(model);
            IProcedureModel insertedModel = ConvertToModel(_repository.Insert(dto));

            return insertedModel;
        }

        public IProcedureModel GetByCode(string code)
        {
            ProcedureDTO dto = _repository.GetByCode(code);
            IProcedureModel model = ConvertToModel(dto);

            return model;
        }

        internal static ProcedureDTO ConvertToDto(IProcedureModel model)
        {
            if (model is null)
            {
                return null;
            }
            ProcedureDTO dto = new ProcedureDTO
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
            };

            return dto;
        }

        internal static IProcedureModel ConvertToModel(ProcedureDTO dto)
        {
            if (dto is null)
            {
                return null;
            }
            IProcedureModel model = new ProcedureModel
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name,
            };

            return model;
        }
    }
}
