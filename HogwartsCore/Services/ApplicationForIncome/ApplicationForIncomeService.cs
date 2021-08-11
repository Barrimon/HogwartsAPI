using HogwartsCore.Entities;
using HogwartsCore.Repositories;
using HogwartsCore.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsCore.Services
{
    public class ApplicationForIncomeService : IApplicationForIncomeService
    {
        private readonly IRepositoryApplicationForIncome repositoryApplicationForIncome;

        public ApplicationForIncomeService(IRepositoryApplicationForIncome repositoryApplicationForIncome)
        {
            this.repositoryApplicationForIncome = repositoryApplicationForIncome;
        }

        public async Task<ApplicationForIncomeModel> Create(ApplicationForIncomeModel model)
        {
            var resul = await repositoryApplicationForIncome.CreateAsync((ApplicationForIncome)model);
            return (ApplicationForIncomeModel)resul;
        }

        public async Task<bool> Update(ApplicationForIncomeModel model)
        {
            var resul = await repositoryApplicationForIncome.UpdateAsync((ApplicationForIncome)model);
            return resul;
        }

        public async Task<bool> Delete(Guid EntityCode)
        {
            var objToDelete = repositoryApplicationForIncome.GetByCodeAsync(EntityCode);
            var resul = repositoryApplicationForIncome.DeleteAsync(objToDelete.Result);
            await Task.WhenAll(objToDelete, resul);
            return resul.Result;
        }

        public async Task<IEnumerable<ApplicationForIncomeModel>> GetAll()
        {
            var resul = (await repositoryApplicationForIncome.GetAllAsync()).Select(x => (ApplicationForIncomeModel)x).ToList();
            return resul;
        }

        public async Task<ApplicationForIncomeModel> GetByCode(Guid EntityCode)
        {
            var resul = (ApplicationForIncomeModel)(await repositoryApplicationForIncome.GetByCodeAsync(EntityCode));
            return resul;
        }
    }
}
