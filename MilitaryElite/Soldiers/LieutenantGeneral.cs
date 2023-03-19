using MilitaryElite.Extensions;

namespace MilitaryElite.Soldiers
{
    public class LieutenantGeneral : PayrolledSoldier
    {
        public IEnumerable<Private> Privates { get; }
        
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary,
            IEnumerable<Private> privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}{this.Privates.FormatForPrint(nameof(this.Privates))}";
        }
    }
}
