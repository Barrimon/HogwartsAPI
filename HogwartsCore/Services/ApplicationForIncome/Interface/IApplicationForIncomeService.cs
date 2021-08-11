using HogwartsCore.Services.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsCore.Services
{
    public interface IApplicationForIncomeService
    {
        Task<ApplicationForIncomeModel> Create(ApplicationForIncomeModel model);
        Task<bool> Delete(Guid EntityCode);
        Task<IEnumerable<ApplicationForIncomeModel>> GetAll();
        Task<ApplicationForIncomeModel> GetByCode(Guid EntityCode);
        Task<bool> Update(ApplicationForIncomeModel model);
    }
}