namespace MilitaryElite.Soldiers.Specialised
{
    public abstract class SpecialisedSoldier : PayrolledSoldier
    {
        public Corps Corps { get; }

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Corps: {this.Corps}";
        }
    }
}
