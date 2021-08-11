using HogwartsCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HogwartsCore.Services.Model
{
    public class FraternityModel
    {
        public string Name { get; set; }
        public ApplicationForIncomeModel ApplicationForIncome { get; set; }

        public static explicit operator FraternityModel(Fraternity entity) => new FraternityModel
        {
            ApplicationForIncome = (ApplicationForIncomeModel)entity.FK_ApplicationForIncome,
            Name = entity.Name
        };

        public static explicit operator Fraternity(FraternityModel entity) => new Fraternity
        {
            FK_ApplicationForIncome = (ApplicationForIncome)entity.ApplicationForIncome,
            Name = entity.Name
        };
    }
}
