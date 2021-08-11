using HogwartsCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HogwartsCore.Services.Model
{
    public class FraternityModel : IdentifierEntity
    {
        public string Name { get; set; }
        public virtual ApplicationForIncomeModel ApplicationForIncome { get; set; }

        public static explicit operator FraternityModel(Fraternity entity) => new FraternityModel
        {
            EntityCode = entity.EntityCode,
            ApplicationForIncome = (ApplicationForIncomeModel)entity.FK_ApplicationForIncome,
            Name = entity.Name
        };

        public static explicit operator Fraternity(FraternityModel model) => new Fraternity
        {
            EntityCode = model.EntityCode,
            FK_ApplicationForIncome = (ApplicationForIncome)model.ApplicationForIncome,
            Name = model.Name
        };
    }
}
