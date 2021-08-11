using HogwartsCore.Entities;
using HogwartsCore.Repositories;
using HogwartsCore.Services;
using HogwartsInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsInfrastructure.Repositories
{
    public class RepositoryApplicationForIncome : BaseRepository<ApplicationForIncome>, IRepositoryApplicationForIncome
    {
        public RepositoryApplicationForIncome(HogwartsContext context, IAppLogger<ApplicationForIncome> logger) : base(context, logger) { }
    }
}
