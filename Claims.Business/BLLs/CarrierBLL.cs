using Claims.Business.Models;
using Claims.Business.Models.Interfaces;
using Claims.Data.DTOs;
using Claims.Data.Repositories;

namespace Claims.Business.BLLs
{
    public class CarrierBLL : BaseBLL<ICarrierModel>
    {
        private readonly CarrierRepository _repository = new CarrierRepository();

        public override ICarrierModel Insert(ICarrierModel model)
        {
            throw new System.NotImplementedException();
        }

        public override ICarrierModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICarrierModel GetByName(string name)
        {
            CarrierDTO dto = _repository.GetByName(name);
            ICarrierModel model = ConvertToModel(dto);

            return model;
        }

        internal static CarrierDTO ConvertToDto(ICarrierModel model)
        {
            if (model is null)
            {
                return null;
            }
            CarrierDTO dto = new CarrierDTO
            {
                Id = model.Id,
                Name = model.Name,
                CustomerServicePhoneNumber = model.CustomerServicePhoneNumber,
            };

            return dto;
        }

        internal static ICarrierModel ConvertToModel(CarrierDTO dto)
        {
            if (dto is null)
            {
                return null;
            }
            ICarrierModel model = new CarrierModel
            {
                Id = dto.Id,
                Name = dto.Name,
                CustomerServicePhoneNumber = dto.CustomerServicePhoneNumber,
            };

            return model;
        }
    }
}
