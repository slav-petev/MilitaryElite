namespace MilitaryElite.Soldiers
{
    public abstract class PayrolledSoldier : Soldier
    {
        public decimal Salary { get; }
        
        protected PayrolledSoldier(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary}";
        }
    }
}
