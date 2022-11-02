using System.Collections.Generic;
using System.Data;

using Claims.Data.DTOs;

namespace Claims.Data.Repositories
{
    public class ClaimRepository : BaseRepository<ClaimDTO>
    {
        public override ClaimDTO Insert(ClaimDTO dto)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@patientLastName", dto.Patient.LastName },
                { "@patientFirstName", dto.Patient.FirstName },
                { "@patientMiddleName", dto.Patient.MiddleName },
                { "@patientStreet", dto.Patient.Street },
                { "@patientCity", dto.Patient.City },
                { "@patientState", dto.Patient.State },
                { "@patientZip", dto.Patient.Zip },
                { "@patientPhoneNumber", dto.Patient.PhoneNumber },
                { "@patientEmailAddress", dto.Patient.EmailAddress },
                { "@carrierName", dto.Carrier.Name },
                { "@carrierCustomerServicePhoneNumber", dto.Carrier.CustomerServicePhoneNumber },
                { "@hospitalName", dto.Hospital.Name },
                { "@hospitalStreet", dto.Hospital.Street },
                { "@hospitalCity", dto.Hospital.City },
                { "@hospitalState", dto.Hospital.State },
                { "@hospitalZip", dto.Hospital.Zip },
                { "@procedureCode", dto.Procedure.Code },
                { "@procedureName", dto.Procedure.Name },
                { "@claimOutstandingAmount", dto.OutstandingAmount },
                { "@claimInsuranceResponsibilityAmount", dto.InsuranceResponsibilityAmount },
            };
            DataTable dataTable = _dal.ExecuteStoredProcedure("dbo.spA_Claim_Insert", parameters);
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            ClaimDTO insertedDto = ConvertToDto(dataTable.Rows[0]);

            return insertedDto;
        }

        public override ClaimDTO GetById(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@claimID", id }
            };
            DataTable dataTable = _dal.ExecuteStoredProcedure("dbo.spA_Claim_GetById", parameters);
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            ClaimDTO dto = ConvertToDto(dataTable.Rows[0]);

            return dto;
        }

        internal static ClaimDTO ConvertToDto(DataRow row)
        {
            ClaimDTO dto = new ClaimDTO
            {
                Id = (int)row["ClaimId"],
                Patient = PatientRepository.ConvertToDto(row),
                Carrier = CarrierRepository.ConvertToDto(row),
                Hospital = HospitalRepository.ConvertToDto(row),
                Procedure = ProcedureRepository.ConvertToDto(row),
                OutstandingAmount = (decimal)row["ClaimOutstandingAmount"],
                InsuranceResponsibilityAmount = (decimal)row["ClaimInsuranceResponsibilityAmount"],
            };

            return dto;
        }
    }
}
