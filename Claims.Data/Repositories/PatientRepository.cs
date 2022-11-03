using System.Collections.Generic;
using System.Data;

using Claims.Data.DTOs;

namespace Claims.Data.Repositories
{
    public class PatientRepository : BaseRepository
    {
        public PatientDTO Insert(PatientDTO dto)
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
            DataTable dataTable = _dal.ExecuteStoredProcedure("dbo.spA_Patient_Insert", parameters);
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            PatientDTO insertedDto = ConvertToDto(dataTable.Rows[0]);

            return insertedDto;
        }

        public List<PatientDTO> GetAllByLastName(string lastName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@patientLastName", lastName },
            };
            DataTable dataTable = _dal.ExecuteStoredProcedure(
                "dbo.spA_Patient_GetAllByLastName",
                parameters
            );
            List<PatientDTO> dtoList = new List<PatientDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                dtoList.Add(ConvertToDto(row));
            }

            return dtoList;
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
