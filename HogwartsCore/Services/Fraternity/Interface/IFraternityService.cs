using HogwartsCore.Services.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsCore.Services
{
    public interface IFraternityService
    {
        Task<FraternityModel> Create(FraternityModel model);
        Task<bool> Delete(Guid EntityCode);
        Task<IEnumerable<FraternityModel>> GetAll();
        Task<bool> Update(FraternityModel model);
    }
}