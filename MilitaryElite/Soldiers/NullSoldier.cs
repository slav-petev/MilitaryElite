using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Soldiers
{
    public class NullSoldier : Soldier
    {
        public NullSoldier() : base(0, string.Empty, string.Empty)
        {

        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
