using MilitaryElite.Soldiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Common
{
    public interface IWriteSoldier
    {
        void Write(Soldier soldier);
    }
}
