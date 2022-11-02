using System;
using System.Collections.Generic;
using System.Data;

using Claims.Data.DTOs;

namespace Claims.Data.Repositories
{
    public class CarrierRepository : BaseRepository<CarrierDTO>
    {
        public CarrierRepository(string connectionString) : base(connectionString) { }

        public override CarrierDTO Insert(CarrierDTO dto)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@carrierName", dto.Name },
                { "@carrierCustomerServicePhoneNumber", dto.CustomerServicePhoneNumber },
            };
            DataTable dataTable = _dal.ExecuteStoredProcedure("dbo.spA_Carrier_Insert", parameters);
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            CarrierDTO insertedDto = ConvertToDto(dataTable.Rows[0]);

            return insertedDto;
        }

        public override CarrierDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal static CarrierDTO ConvertToDto(DataRow row)
        {
            CarrierDTO dto = new CarrierDTO
            {
                Id = (int)row["CarrierId"],
                Name = (string)row["CarrierName"],
                CustomerServicePhoneNumber = (string)row["CarrierCustomerServicePhoneNumber"],
            };

            return dto;
        }
    }
}
