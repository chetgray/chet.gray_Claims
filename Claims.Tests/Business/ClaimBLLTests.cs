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
        /// Tests that inserting an second empty Claim creates a new record.
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
    }
}
