using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogwartsCore.Entities
{
    public class ApplicationForIncome : IdentifierEntity
    {
        [MaxLength(20, ErrorMessage = "{0} allow {1} characters as maximum")]
        public string Name { get; set; }
        [MaxLength(20, ErrorMessage = "{0} allow {1} characters as maximum")]
        public string LastName { get; set; }
        [Range(1, 999999999, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} must be numeric")]
        public int Identification { get; set; }
        [Range(1, 999999999, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} must be numeric")]
        public int Age { get; set; }
        public Guid EntityCodeFraternity { get; set; }
        [ForeignKey("EntityCodeFraternity")]
        public virtual Fraternity FK_Fraternity { get; set; }
    }
}
