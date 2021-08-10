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
        [MaxLength(10, ErrorMessage = "{0} allow {1} digits as maximum")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} must be numeric")]
        public int Identification { get; set; }
        [MaxLength(2, ErrorMessage = "{0} allow {1} digits as maximum")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} must be numeric")]
        public int Age { get; set; }

        [Required]
        [MaxLength(50)]
        public Guid EntityCodeFraternity { get; set; }
        [ForeignKey(nameof(EntityCodeFraternity))]
        public virtual Fraternity Fk_Fraternity { get; set; }
    }
}
