using HogwartsCore.Entities;
using HogwartsCore.Repositories;
using HogwartsCore.Services;
using HogwartsInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsInfrastructure.Repositories
{
    public class RepositoryFraternity : BaseRepository<Fraternity>, IRepositoryFraternity
    {
        public RepositoryFraternity(HogwartsContext context, IAppLogger<Fraternity> logger) : base(context, logger) { }
    }
}
