using HogwartsCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsCore.Services
{
    public class ApplicationForIncomeService
    {
        private readonly IRepositoryApplicationForIncome repositoryApplicationForIncome;

        public ApplicationForIncomeService(IRepositoryApplicationForIncome repositoryApplicationForIncome)
        {
            this.repositoryApplicationForIncome = repositoryApplicationForIncome;
        }
    }
}
