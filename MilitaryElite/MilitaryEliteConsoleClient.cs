using MilitaryElite;
using MilitaryElite.Common;
using MilitaryElite.Soldiers;

var soldiersFactory = new SoldiersFactory();
IWriteSoldier soldierWriter = new ConsoleWriteSoldier();
var soldiers = new List<Soldier>();
var input = Console.ReadLine();
while (!string.Equals(input, "End", StringComparison.InvariantCultureIgnoreCase))
{
    soldiers.Add(soldiersFactory.FromString(input));
    
    input = Console.ReadLine();
}

soldiers.ForEach(soldierWriter.Write);