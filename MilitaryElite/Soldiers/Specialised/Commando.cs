using MilitaryElite.Extensions;
using MilitaryElite.Soldiers.Specialised.Missions;

namespace MilitaryElite.Soldiers.Specialised
{
    public class Commando : SpecialisedSoldier
    {
        public IEnumerable<Mission> Missions { get; }
        
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, IEnumerable<Mission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}{this.Missions.FormatForPrint(nameof(this.Missions))}";
        }
    }
}
