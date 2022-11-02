using System;
using System.Collections.Generic;
using System.Data;

using Claims.Data.DTOs;

namespace Claims.Data.Repositories
{
    public class PatientRepository : BaseRepository<PatientDTO>
    {
        public PatientRepository(string connectionString) : base(connectionString) { }

        public override PatientDTO Insert(PatientDTO dto)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@patientLastName", dto.LastName },
                { "@patientFirstName", dto.FirstName },
                { "@patientMiddleName", dto.MiddleName },
                { "@patientStreet", dto.Street },
                { "@patientCity", dto.City },
                { "@patientState", dto.State },
                { "@patientZip", dto.Zip },
                { "@patientPhoneNumber", dto.PhoneNumber },
                { "@patientEmailAddress", dto.EmailAddress },
            };
            DataTable dataTable = _dal.ExecuteStoredProcedure("spA_Patient_Insert", parameters);
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            PatientDTO insertedDto = ConvertToDto(dataTable.Rows[0]);

            return insertedDto;
        }

        public override PatientDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal static PatientDTO ConvertToDto(DataRow row)
        {
            PatientDTO dto = new PatientDTO
            {
                Id = (int)row["PatientId"],
                LastName = (string)row["PatientLastName"],
                FirstName = (string)row["PatientFirstName"],
                MiddleName = (string)row["PatientMiddleName"],
                Street = (string)row["PatientStreet"],
                City = (string)row["PatientCity"],
                State = (string)row["PatientState"],
                Zip = (string)row["PatientZip"],
                PhoneNumber = (string)row["PatientPhoneNumber"],
                EmailAddress = (string)row["PatientEmailAddress"],
            };

            return dto;
        }
    }
}
