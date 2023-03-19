using MilitaryElite.Soldiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Common
{
    public class ConsoleWriteSoldier : IWriteSoldier
    {
        public void Write(Soldier soldier)
        {
            if (!string.IsNullOrWhiteSpace(soldier.ToString()))
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
