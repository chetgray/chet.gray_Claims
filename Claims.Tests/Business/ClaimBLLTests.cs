using Claims.Business.BLLs;
using Claims.Business.Models;
using Claims.Business.Models.Interfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims.Tests.Business
{
    [TestClass]
    public class ClaimBLLTests
    {
        /// <summary>
        ///     Tests that inserting an empty Claim creates a new record.
        /// </summary>
        /// <remarks>
        ///     All claims are unique, and we can have multiple claims with the
        ///     same Patient, Carrier, Hospital, and Procedure, so inserting a
        ///     claim should create a new record no matter what the data is.
        /// </remarks>
        [TestMethod]
        public void TestInsertEmptyCreatesNewRecord()
        {
            // Arrange
            ClaimBLL claimBLL = new ClaimBLL();
            IClaimModel claim = new ClaimModel();

            // Act
            IClaimModel insertedClaim = claimBLL.Insert(claim);

            // Assert
            Assert.IsNotNull(insertedClaim);
        }

        /// <summary>
        ///     Tests that inserting an second empty Claim creates a new record.
        /// </summary>
        /// <remarks>
        ///     All claims are unique, and we can have multiple claims with the
        ///     same Patient, Carrier, Hospital, and Procedure, so inserting a
        ///     claim with the same field data as one that already exists should
        ///     still create a new record.
        /// </remarks>
        [TestMethod]
        public void TestInsertIdenticalEmptyCreatesNewRecord()
        {
            // Arrange
            ClaimBLL claimBLL = new ClaimBLL();
            IClaimModel firstClaim = new ClaimModel();
            IClaimModel secondClaim = new ClaimModel();
            claimBLL.Insert(firstClaim);

            // Act
            IClaimModel insertedClaim = claimBLL.Insert(secondClaim);

            // Assert
            Assert.IsNotNull(insertedClaim);
        }

        /// <summary>
        ///     Tests that the result of inserting a Claim has the same unique
        ///     data as the original claim.
        /// </summary>
        /// <remarks>
        ///     This tests only invariant fields, that will always be the same.
        ///     Procedure fields are not checked because it is unique for
        ///     *either* Code or Name, so the returned result could be whatever
        ///     already existed in the database that matched either field.
        /// </remarks>
        [TestMethod]
        public void TestInsertResultHasSameUniqueData()
        {
            // Arrange
            ClaimBLL claimBLL = new ClaimBLL();
            IClaimModel claim = CreateExampleClaimModel();

            // Act
            IClaimModel insertedClaim = claimBLL.Insert(claim);

            // Assert
            Assert.AreEqual(claim.Patient.LastName, insertedClaim.Patient.LastName);
            Assert.AreEqual(claim.Patient.FirstName, insertedClaim.Patient.FirstName);
            Assert.AreEqual(claim.Patient.MiddleName, insertedClaim.Patient.MiddleName);
            Assert.AreEqual(claim.Patient.Street, insertedClaim.Patient.Street);
            Assert.AreEqual(claim.Patient.City, insertedClaim.Patient.City);
            Assert.AreEqual(claim.Patient.State, insertedClaim.Patient.State);
            Assert.AreEqual(claim.Patient.Zip, insertedClaim.Patient.Zip);
            Assert.AreEqual(claim.Patient.PhoneNumber, insertedClaim.Patient.PhoneNumber);
            Assert.AreEqual(claim.Patient.EmailAddress, insertedClaim.Patient.EmailAddress);
            Assert.AreEqual(claim.Carrier.Name, insertedClaim.Carrier.Name);
            Assert.AreEqual(claim.Hospital.Name, insertedClaim.Hospital.Name);
            Assert.AreEqual(claim.OutstandingAmount, insertedClaim.OutstandingAmount);
            Assert.AreEqual(
                claim.InsuranceResponsibilityAmount,
                insertedClaim.InsuranceResponsibilityAmount
            );
        }

        [TestMethod]
        public void TestGetByIdZeroReturnsNull()
        {
            // Arrange
            ClaimBLL claimBLL = new ClaimBLL();

            // Act
            IClaimModel retrievedClaim = claimBLL.GetById(0);

            // Assert
            Assert.IsNull(retrievedClaim);
        }

        [TestMethod]
        public void TestGetByIdNegativeReturnsNull()
        {
            // Arrange
            ClaimBLL claimBLL = new ClaimBLL();

            // Act
            IClaimModel retrievedClaim = claimBLL.GetById(-1);

            // Assert
            Assert.IsNull(retrievedClaim);
        }

        [TestMethod]
        public void TestGetByIdBeyondLastInsertedReturnsNull()
        {
            // Arrange
            ClaimBLL claimBLL = new ClaimBLL();
            IClaimModel claim = new ClaimModel();
            IClaimModel insertedClaim = claimBLL.Insert(claim);

            // Act
            IClaimModel retrievedClaim = claimBLL.GetById((int)insertedClaim.Id + 1);

            // Assert
            Assert.IsNull(retrievedClaim);
        }

        [TestMethod]
        public void TestGetByIdExistingReturnsRecordWithThatId()
        {
            // Arrange
            ClaimBLL claimBLL = new ClaimBLL();
            IClaimModel claim = new ClaimModel();
            IClaimModel insertedClaim = claimBLL.Insert(claim);

            // Act
            IClaimModel retrievedClaim = claimBLL.GetById((int)insertedClaim.Id);

            // Assert
            Assert.AreEqual(insertedClaim.Id, retrievedClaim.Id);
        }

        [TestMethod]
        public void TestGetByIdExistingReturnsSameData()
        {
            // Arrange
            ClaimBLL claimBLL = new ClaimBLL();
            IClaimModel claim = CreateExampleClaimModel();
            IClaimModel insertedClaim = claimBLL.Insert(claim);

            // Act
            IClaimModel retrievedClaim = claimBLL.GetById((int)insertedClaim.Id);

            // Assert
            Assert.AreEqual(insertedClaim.Id, retrievedClaim.Id);
            Assert.AreEqual(insertedClaim.Patient.Id, retrievedClaim.Patient.Id);
            Assert.AreEqual(insertedClaim.Patient.LastName, retrievedClaim.Patient.LastName);
            Assert.AreEqual(insertedClaim.Patient.FirstName, retrievedClaim.Patient.FirstName);
            Assert.AreEqual(insertedClaim.Patient.MiddleName, retrievedClaim.Patient.MiddleName);
            Assert.AreEqual(insertedClaim.Patient.Street, retrievedClaim.Patient.Street);
            Assert.AreEqual(insertedClaim.Patient.City, retrievedClaim.Patient.City);
            Assert.AreEqual(insertedClaim.Patient.State, retrievedClaim.Patient.State);
            Assert.AreEqual(insertedClaim.Patient.Zip, retrievedClaim.Patient.Zip);
            Assert.AreEqual(insertedClaim.Patient.PhoneNumber, retrievedClaim.Patient.PhoneNumber);
            Assert.AreEqual(insertedClaim.Patient.EmailAddress, retrievedClaim.Patient.EmailAddress);
            Assert.AreEqual(insertedClaim.Carrier.Id, retrievedClaim.Carrier.Id);
            Assert.AreEqual(insertedClaim.Carrier.Name, retrievedClaim.Carrier.Name);
            Assert.AreEqual(insertedClaim.Carrier.CustomerServicePhoneNumber, retrievedClaim.Carrier.CustomerServicePhoneNumber);
            Assert.AreEqual(insertedClaim.Hospital.Id, retrievedClaim.Hospital.Id);
            Assert.AreEqual(insertedClaim.Hospital.Name, retrievedClaim.Hospital.Name);
            Assert.AreEqual(insertedClaim.Hospital.Street, retrievedClaim.Hospital.Street);
            Assert.AreEqual(insertedClaim.Hospital.City, retrievedClaim.Hospital.City);
            Assert.AreEqual(insertedClaim.Hospital.State, retrievedClaim.Hospital.State);
            Assert.AreEqual(insertedClaim.Hospital.Zip, retrievedClaim.Hospital.Zip);
            Assert.AreEqual(insertedClaim.Procedure.Id, retrievedClaim.Procedure.Id);
            Assert.AreEqual(insertedClaim.Procedure.Code, retrievedClaim.Procedure.Code);
            Assert.AreEqual(insertedClaim.Procedure.Name, retrievedClaim.Procedure.Name);
            Assert.AreEqual(insertedClaim.OutstandingAmount, retrievedClaim.OutstandingAmount);
            Assert.AreEqual(insertedClaim.InsuranceResponsibilityAmount, retrievedClaim.InsuranceResponsibilityAmount);
        }

        private static IClaimModel CreateExampleClaimModel()
        {
            IClaimModel claim = new ClaimModel
            {
                Patient = new PatientModel
                {
                    LastName = "patient last name",
                    FirstName = "patient first name",
                    MiddleName = "patient middle name",
                    Street = "patient street",
                    City = "patient city",
                    State = "patient state",
                    // Zip is limited to 5 characters
                    Zip = "p zip",
                    PhoneNumber = "patient phone number",
                    EmailAddress = "patient email address",
                },
                Carrier = new CarrierModel { Name = "carrier name", },
                Hospital = new HospitalModel { Name = "hospital name", },
                OutstandingAmount = decimal.One,
                InsuranceResponsibilityAmount = decimal.One
            };

            return claim;
        }
    }
}
