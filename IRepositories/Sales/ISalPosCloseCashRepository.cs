﻿using LogixApi_v02.TestModels;

namespace LogixApi_v02.IRepositories.Sales
{
    public interface ISalPosCloseCashRepository : IGenericRepository<SalPosCloseCash>
    {
        public  Task AddISalPosCloseCash( SalPosCloseCash salPosCloseCash);


    }



}