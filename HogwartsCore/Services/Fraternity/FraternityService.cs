using HogwartsCore.Entities;
using HogwartsCore.Repositories;
using HogwartsCore.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsCore.Services
{
    public class FraternityService : IFraternityService
    {
        private readonly IRepositoryFraternity fraternitrepositoryy;

        public FraternityService(IRepositoryFraternity Fraternitrepositoryy)
        {
            this.fraternitrepositoryy = Fraternitrepositoryy;
        }

        public async Task<FraternityModel> Create(FraternityModel model)
        {
            var resul = await fraternitrepositoryy.CreateAsync((Fraternity)model);
            return (FraternityModel)resul;
        }


        public async Task<bool> Update(FraternityModel model)
        {
            var resul = await fraternitrepositoryy.UpdateAsync((Fraternity)model);
            return resul;
        }

        public async Task<bool> Delete(Guid EntityCode)
        {
            var objToDelete = fraternitrepositoryy.GetByCodeAsync(EntityCode);
            var result = fraternitrepositoryy.DeleteAsync(objToDelete.Result);
            await Task.WhenAll(objToDelete, result);
            return result.Result;
        }

        public async Task<IEnumerable<FraternityModel>> GetAll()
        {
            var resul = (IEnumerable<FraternityModel>)(await fraternitrepositoryy.GetAllAsync()).ToList();
            return resul;
        }
    }
}
