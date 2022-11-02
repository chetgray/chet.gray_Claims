using Claims.Business.Models;
using Claims.Business.Models.Interfaces;
using Claims.Data.DTOs;
using Claims.Data.Repositories;

namespace Claims.Business.BLLs
{
    public class ClaimBLL : BaseBLL<IClaimModel>
    {
        private readonly ClaimRepository _repository;

        public ClaimBLL(string connectionString) : base(connectionString)
        {
            _repository = new ClaimRepository(_connectionString);
        }

        public override IClaimModel Insert(IClaimModel model)
        {
            ClaimDTO dto = ConvertToDto(model);
            IClaimModel insertedModel = ConvertToModel(_repository.Insert(dto));

            return insertedModel;
        }

        public override IClaimModel GetById(int id)
        {
            ClaimDTO dto = _repository.GetById(id);
            IClaimModel model = ConvertToModel(dto);

            return model;
        }

        private ClaimDTO ConvertToDto(IClaimModel model)
        {
            if (model is null)
            {
                return null;
            }
            ClaimDTO dto = new ClaimDTO
            {
                Id = model.Id,
                Patient = PatientBLL.ConvertToDto(model.Patient),
                Carrier = CarrierBLL.ConvertToDto(model.Carrier),
                Hospital = HospitalBLL.ConvertToDto(model.Hospital),
                Procedure = ProcedureBLL.ConvertToDto(model.Procedure),
                OutstandingAmount = model.OutstandingAmount,
                InsuranceResponsibilityAmount = model.InsuranceResponsibilityAmount,
            };

            return dto;
        }

        private IClaimModel ConvertToModel(ClaimDTO dto)
        {
            if (dto is null)
            {
                return null;
            }
            IClaimModel model = new ClaimModel
            {
                Id = dto.Id,
                Patient = PatientBLL.ConvertToModel(dto.Patient),
                Carrier = CarrierBLL.ConvertToModel(dto.Carrier),
                Hospital = HospitalBLL.ConvertToModel(dto.Hospital),
                Procedure = ProcedureBLL.ConvertToModel(dto.Procedure),
                OutstandingAmount = dto.OutstandingAmount,
                InsuranceResponsibilityAmount = dto.InsuranceResponsibilityAmount,
            };

            return model;
        }
    }
}
