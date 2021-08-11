using HogwartsCore.Entities;
using HogwartsCore.Models;
using System;

namespace HogwartsCore.Services.Model
{
    public class FraternityModel : IdentifierEntityModel
    {
        public string Name { get; set; }
        public virtual ApplicationForIncomeModel ApplicationForIncome { get; set; }

        public static explicit operator FraternityModel(Fraternity entity) => new FraternityModel
        {
            EntityCode = entity.EntityCode.ToString(),
            ApplicationForIncome = (ApplicationForIncomeModel)entity.FK_ApplicationForIncome,
            Name = entity.Name
        };

        public static explicit operator Fraternity(FraternityModel model) => new Fraternity
        {
            EntityCode = Guid.Parse(model.EntityCode),
            Name = model.Name
        };
    }
}
