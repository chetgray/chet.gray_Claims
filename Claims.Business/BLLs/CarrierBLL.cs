using Claims.Business.Models;
using Claims.Business.Models.Interfaces;
using Claims.Data.DTOs;

namespace Claims.Business.BLLs
{
    public class CarrierBLL : BaseBLL<ICarrierModel>
    {
        public CarrierBLL(string connectionString) : base(connectionString) { }

        public override ICarrierModel Insert(ICarrierModel model)
        {
            throw new System.NotImplementedException();
        }

        public override ICarrierModel GetById(int id)
        {
            throw new System.NotImplementedException();
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
