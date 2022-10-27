﻿using System;

using Claims.Data.DTOs;

namespace Claims.Data.Repositories
{
    public class ClaimRepository : BaseRepository<ClaimDTO>
    {
        public ClaimRepository(string connectionString) : base(connectionString) { }

        public override ClaimDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}