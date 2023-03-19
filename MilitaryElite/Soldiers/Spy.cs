namespace MilitaryElite.Soldiers
{
    public class Spy : Soldier
    {
        public int CodeNumber { get; }
        
        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Code Number: {this.CodeNumber}";
        }
    }
}
