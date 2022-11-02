using System.Collections.Generic;

using Claims.Business.Models;
using Claims.Business.Models.Interfaces;
using Claims.Data.DTOs;
using Claims.Data.Repositories;

namespace Claims.Business.BLLs
{
    public class PatientBLL : BaseBLL<IPatientModel>
    {
        private readonly PatientRepository _repository;

        public PatientBLL(string connectionString) : base(connectionString)
        {
            _repository = new PatientRepository(_connectionString);
        }

        public override IPatientModel Insert(IPatientModel model)
        {
            throw new System.NotImplementedException();
        }

        public override IPatientModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<IPatientModel> GetAllByLastName(string lastName)
        {
            List<PatientDTO> dtoList = _repository.GetAllByLastName(lastName);
            List<IPatientModel> modelList = new List<IPatientModel>();

            foreach (PatientDTO dto in dtoList)
            {
                modelList.Add(ConvertToModel(dto));
            }

            return modelList;
        }

        internal static PatientDTO ConvertToDto(IPatientModel model)
        {
            if (model is null)
            {
                return null;
            }
            PatientDTO dto = new PatientDTO
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                Street = model.Street,
                City = model.City,
                State = model.State,
                Zip = model.Zip,
                PhoneNumber = model.PhoneNumber,
                EmailAddress = model.EmailAddress,
            };

            return dto;
        }

        internal static IPatientModel ConvertToModel(PatientDTO dto)
        {
            if (dto is null)
            {
                return null;
            }
            IPatientModel model = new PatientModel
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                Street = dto.Street,
                City = dto.City,
                State = dto.State,
                Zip = dto.Zip,
                PhoneNumber = dto.PhoneNumber,
                EmailAddress = dto.EmailAddress,
            };

            return model;
        }
    }
}
