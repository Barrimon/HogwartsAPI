namespace HogwartsCore.Entities
{
    public class Fraternity : IdentifierEntity
    {
        public string Name { get; set; }

        public virtual ApplicationForIncome FK_ApplicationForIncome { get; set; }
    }
}
