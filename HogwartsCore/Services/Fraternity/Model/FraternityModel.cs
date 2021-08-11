using HogwartsCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HogwartsCore.Services.Model
{
    public class FraternityModel
    {
        public string Name { get; set; }
        public ICollection<ApplicationForIncomeModel> ApplicationForIncome { get; set; }

        public static explicit operator FraternityModel(Fraternity entity) => new FraternityModel
        {
            ApplicationForIncome = entity.FK_ApplicationForIncome.Select(x => (ApplicationForIncomeModel)x).ToList(),
            Name = entity.Name
        };

        public static explicit operator Fraternity(FraternityModel entity) => new Fraternity
        {
            FK_ApplicationForIncome = entity.ApplicationForIncome.Select(x => (ApplicationForIncome)x).ToList(),
            Name = entity.Name
        };
    }
}
