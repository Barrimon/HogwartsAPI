using HogwartsCore.Entities;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace HogwartsCore.Services.Model
{
    public class ApplicationForIncomeModel : IdentifierEntity
    {
        [MaxLength(20, ErrorMessage = "{0} allow {1} characters as maximum")]
        public string Name { get; set; }
        [MaxLength(20, ErrorMessage = "{0} allow {1} characters as maximum")]
        public string LastName { get; set; }
        [Range(1, 999999999,ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} must be numeric")]
        public int Identification { get; set; }
        [Range(1, 99, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} must be numeric")]
        public int Age { get; set; }



        public static explicit operator ApplicationForIncomeModel(ApplicationForIncome entity) => new ApplicationForIncomeModel
        {
            EntityCode = entity.EntityCode,
            Age = entity.Age,
            //EntityCodeFraternity = entity.EntityCodeFraternity,
            //Fraternity = (FraternityModel)entity.Fk_Fraternity,
            Identification = entity.Identification,
            LastName = entity.LastName,
            Name = entity.Name

        };

        public static explicit operator ApplicationForIncome (ApplicationForIncomeModel model) => new ApplicationForIncome
        {
            EntityCode = model.EntityCode,
            Age = model.Age,
            //EntityCodeFraternity = model.EntityCodeFraternity,
            //Fk_Fraternity = (Fraternity)model.Fraternity,
            Identification = model.Identification,
            LastName = model.LastName,
            Name = model.Name

        };
    }
}
