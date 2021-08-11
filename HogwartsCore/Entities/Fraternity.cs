using HogwartsCore.Services.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HogwartsCore.Entities
{
    public class Fraternity : IdentifierEntity
    {
        public string Name { get; set; }

        public virtual ApplicationForIncome FK_ApplicationForIncome { get; set; }
    }
}
