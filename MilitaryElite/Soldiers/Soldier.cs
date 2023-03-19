namespace MilitaryElite.Soldiers
{
    public abstract class Soldier
    {
        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }
        
        protected Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
