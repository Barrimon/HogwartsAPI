using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HogwartsCore.Models
{
    public abstract class IdentifierEntityModel
    {
        [Required(ErrorMessage ="{0} is Required")]
        [MaxLength(50, ErrorMessage = "{0} allow {1} characters as maximum")]
        public string EntityCode { get; set; }

    }
}
