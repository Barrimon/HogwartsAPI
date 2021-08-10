using System;
using System.ComponentModel.DataAnnotations;

namespace HogwartsCore.Entities
{
    public abstract class IdentifierEntity
    {
        [Key]
        public Guid EntityCode { get; set; }
    }
}
