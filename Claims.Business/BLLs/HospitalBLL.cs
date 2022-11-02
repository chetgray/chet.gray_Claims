using Claims.Business.Models;
using Claims.Business.Models.Interfaces;
using Claims.Data.DTOs;
using Claims.Data.Repositories;

namespace Claims.Business.BLLs
{
    public class HospitalBLL : BaseBLL<IHospitalModel>
    {
        private readonly HospitalRepository _repository;

        public HospitalBLL(string connectionString) : base(connectionString)
        {
            _repository = new HospitalRepository(connectionString);
        }

        public override IHospitalModel Insert(IHospitalModel model)
        {
            throw new System.NotImplementedException();
        }

        public override IHospitalModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IHospitalModel GetByName(string name)
        {
            HospitalDTO dto = _repository.GetByName(name);
            IHospitalModel model = ConvertToModel(dto);

            return model;
        }

        internal static HospitalDTO ConvertToDto(IHospitalModel model)
        {
            if (model is null)
            {
                return null;
            }
            HospitalDTO dto = new HospitalDTO
            {
                Id = model.Id,
                Name = model.Name,
                Street = model.Street,
                City = model.City,
                State = model.State,
                Zip = model.Zip,
            };

            return dto;
        }

        internal static IHospitalModel ConvertToModel(HospitalDTO dto)
        {
            if (dto is null)
            {
                return null;
            }
            IHospitalModel model = new HospitalModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Street = dto.Street,
                City = dto.City,
                State = dto.State,
                Zip = dto.Zip,
            };

            return model;
        }
    }
}
