using Claims.Business.BLLs;
using Claims.Business.Models;
using Claims.Business.Models.Interfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims.Tests.Business
{
    [TestClass]
    public class ClaimBLLTests
    {
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
    }
}
