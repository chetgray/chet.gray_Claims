using System;

using Claims.Business.Models.Interfaces;

namespace Claims.Business.BLLs
{
    public class ClaimBLL : BaseBLL<IClaimModel>
    {
        public ClaimBLL(string connectionString) : base(connectionString)
        {
        }

        public override IClaimModel Insert(IClaimModel model)
        {
            throw new System.NotImplementedException();
        }

        public override IClaimModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
