using HogwartsCore.Entities;
using HogwartsCore.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace HogwartsCore.Services.Model
{
    public class ApplicationForIncomeModel : IdentifierEntityModel
    {
        [MaxLength(20, ErrorMessage = "{0} allow {1} characters as maximum")]
        public string Name { get; set; }
        [MaxLength(20, ErrorMessage = "{0} allow {1} characters as maximum")]
        public string LastName { get; set; }
        [Range(1, 999999999, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} must be numeric")]
        public int Identification { get; set; }
        [Range(1, 99, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} must be numeric")]
        public int Age { get; set; }

        [Required(ErrorMessage ="{0} is Required")]
        [MaxLength(50, ErrorMessage = "{0} allow {1} characters as maximum")]
        public string FraternityEntityCode { get; set; }



        public static explicit operator ApplicationForIncomeModel(ApplicationForIncome entity) => new ApplicationForIncomeModel
        {
            EntityCode = entity.EntityCode.ToString(),
            Age = entity.Age,
            FraternityEntityCode = entity.EntityCodeFraternity.ToString(),
            Identification = entity.Identification,
            LastName = entity.LastName,
            Name = entity.Name

        };

        public static explicit operator ApplicationForIncome(ApplicationForIncomeModel model) => new ApplicationForIncome
        {
            EntityCode = Guid.Parse(model.EntityCode),
            Age = model.Age,
            EntityCodeFraternity = Guid.Parse(model.FraternityEntityCode),
            Identification = model.Identification,
            LastName = model.LastName,
            Name = model.Name

        };
    }
}
