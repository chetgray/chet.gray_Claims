﻿using System;

using Claims.Business.Models.Interfaces;

namespace Claims.Business.BLLs
{
    public class ClaimBLL : IBaseBLL<IClaimModel>
    {
        public IClaimModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
