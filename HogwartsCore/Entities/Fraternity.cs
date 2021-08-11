using HogwartsCore.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsCore.Entities
{
    public class Fraternity : IdentifierEntity
    {
        public string Name { get; set; }

        public ICollection<ApplicationForIncome> FK_ApplicationForIncome { get; set; }

        public static explicit operator Fraternity(ApplicationForIncomeModel v)
        {
            throw new NotImplementedException();
        }
    }
}
