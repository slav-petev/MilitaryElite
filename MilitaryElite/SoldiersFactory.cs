using MilitaryElite.Extensions;
using MilitaryElite.Soldiers;
using MilitaryElite.Soldiers.Specialised;
using MilitaryElite.Soldiers.Specialised.Missions;
using System.Globalization;

namespace MilitaryElite
{
    public class SoldiersFactory
    {
        private const string PRIVATE = "Private";
        private const string LIEUTENANT_GENERAL = "LieutenantGeneral";
        private const string ENGINEER = "Engineer";
        private const string COMMANDO = "Commando";
        private const string SPY = "Spy";

        private readonly Dictionary<int, Private> _privates = new();

        public Soldier FromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input mustn't be empty", nameof(input));
            }
            
            var inputParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var soldierType = inputParts[0];
            var parameters = inputParts.Skip(1);
            switch (soldierType)
            {
                case PRIVATE:
                    var soldier = this.CreatePrivate(parameters);
                    this._privates.Add(soldier.Id, (Private)soldier);

                    return soldier;
                case LIEUTENANT_GENERAL:
                    return this.CreateLieutenantGeneral(parameters);
                case ENGINEER:
                    return this.CreateEngineer(parameters);
                case COMMANDO:
                    return this.CreateCommando(parameters);
                case SPY:
                    return this.CreateSpy(parameters);
                default:
                    throw new ArgumentException($"Unsupported soldier {soldierType}", nameof(soldierType));
            }
        }

        private Soldier CreatePrivate(IEnumerable<string> parameters)
        {
            if (parameters.Count() != 4)
            {
                throw new ArgumentException($"Private: You must provide Id, FirstName, LastName, Salary", nameof(parameters));
            }

            var id = int.Parse(parameters.First());
            var firstName = parameters.Skip(1).First();
            var lastName = parameters.Skip(2).First();
            var salary = decimal.Parse(parameters.Skip(3).First(), CultureInfo.InvariantCulture);

            return new Private(id, firstName, lastName, salary);
        }

        private Soldier CreateLieutenantGeneral(IEnumerable<string> parameters)
        {
            if (parameters.Count() < 4)
            {
                throw new ArgumentException($"{nameof(LieutenantGeneral)}: You must provide at least Id, FirstName, LastName, Salary", nameof(parameters));
            }

            var id = int.Parse(parameters.First());
            var firstName = parameters.Skip(1).First();
            var lastName = parameters.Skip(2).First();
            var salary = decimal.Parse(parameters.Skip(3).First(), CultureInfo.InvariantCulture);
            var privates = parameters
                .Skip(4)
                .Select(int.Parse)
                .Select(id => this._privates[id]);

            return new LieutenantGeneral(id, firstName, lastName, salary, privates);
        }

        private Soldier CreateEngineer(IEnumerable<string> parameters)
        {
            if (parameters.Count() < 5)
            {
                throw new ArgumentException($"{nameof(Engineer)}: You must provide at least Id, FirstName, LastName, Salary, Corps", nameof(parameters));
            }

            var id = int.Parse(parameters.First());
            var firstName = parameters.Skip(1).First();
            var lastName = parameters.Skip(2).First();
            var salary = decimal.Parse(parameters.Skip(3).First(), CultureInfo.InvariantCulture);
            var validCorps = Enum.TryParse(parameters.Skip(4).First(), false, out Corps corps);
            if (!validCorps)
            {
                return new NullSoldier();
            }

            var repairsParameters = parameters
                .Skip(5)
                .ToArray();
            var repairs = new List<Repair>();

            for (var i = 0; i < repairsParameters.Length; i += 2)
            {
                repairs.Add(new Repair(repairsParameters[i], int.Parse(repairsParameters[i + 1])));
            }

            return new Engineer(id, firstName, lastName, salary, corps, repairs);
        }

        private Soldier CreateCommando(IEnumerable<string> parameters)
        {
            if (parameters.Count() < 5)
            {
                throw new ArgumentException($"{nameof(Engineer)}: You must provide at least Id, FirstName, LastName, Salary, Corps", nameof(parameters));
            }

            var id = int.Parse(parameters.First());
            var firstName = parameters.Skip(1).First();
            var lastName = parameters.Skip(2).First();
            var salary = decimal.Parse(parameters.Skip(3).First(), CultureInfo.InvariantCulture);
            var validCorps = Enum.TryParse(parameters.Skip(4).First(), false, out Corps corps);
            if (!validCorps)
            {
                return new NullSoldier();
            }

            var missions = parameters
                .Skip(5)
                .Pair()
                .Select(Mission.FromPair);

            return new Commando(id, firstName, lastName, salary, corps, missions);

        }

        private Soldier CreateSpy(IEnumerable<string> parameters)
        {
            if (parameters.Count() != 4)
            {
                throw new ArgumentException($"{nameof(Spy)}: You must provide Id, First Name, Last Name, Code Number");
            }

            var id = int.Parse(parameters.First());
            var firstName = parameters.Skip(1).First();
            var lastName = parameters.Skip(2).First();
            var codeNumber = int.Parse(parameters.Skip(3).First());

            return new Spy(id, firstName, lastName, codeNumber);
        }
    }
}
