using HogwartsCore.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace HogwartsCore.Services.Model
{
    public class ApplicationForIncomeModel
    {
        [MaxLength(20, ErrorMessage = "{0} allow {1} characters as maximum")]
        public string Name { get; set; }
        [MaxLength(20, ErrorMessage = "{0} allow {1} characters as maximum")]
        public string LastName { get; set; }
        [MaxLength(10, ErrorMessage = "{0} allow {1} digits as maximum")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} must be numeric")]
        public int Identification { get; set; }
        [MaxLength(2, ErrorMessage = "{0} allow {1} digits as maximum")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} must be numeric")]
        public int Age { get; set; }

        [Required]
        [MaxLength(50)]
        public Guid EntityCodeFraternity { get; set; }

        public virtual FraternityModel Fraternity { get; set; }

        public static explicit operator ApplicationForIncomeModel(ApplicationForIncome entity) => new ApplicationForIncomeModel
        {
            Age = entity.Age,
            EntityCodeFraternity = entity.EntityCodeFraternity,
            Fraternity = (FraternityModel)entity.Fk_Fraternity,
            Identification = entity.Identification,
            LastName = entity.LastName,
            Name = entity.Name

        };

        public static explicit operator ApplicationForIncome (ApplicationForIncomeModel model) => new ApplicationForIncome
        {
            Age = model.Age,
            EntityCodeFraternity = model.EntityCodeFraternity,
            Fk_Fraternity = (Fraternity)model.Fraternity,
            Identification = model.Identification,
            LastName = model.LastName,
            Name = model.Name

        };
    }
}
