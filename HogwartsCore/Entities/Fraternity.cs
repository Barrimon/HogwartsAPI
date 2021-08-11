using System.Collections;
using System.Collections.Generic;

namespace HogwartsCore.Entities
{
    public class Fraternity : IdentifierEntity
    {
        public string Name { get; set; }

        public virtual ICollection<ApplicationForIncome> FK_ApplicationForIncome { get; set; }
    }
}
