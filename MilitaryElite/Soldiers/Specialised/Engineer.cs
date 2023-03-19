using MilitaryElite.Extensions;

namespace MilitaryElite.Soldiers.Specialised
{
    public class Engineer : SpecialisedSoldier
    {
        public IEnumerable<Repair> Repairs { get; }
        
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, IEnumerable<Repair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}{this.Repairs.FormatForPrint(nameof(this.Repairs))}";
        }
    }
}
