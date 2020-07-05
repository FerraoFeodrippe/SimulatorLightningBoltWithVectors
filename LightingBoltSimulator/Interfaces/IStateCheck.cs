using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightingBoltSimulator.Interfaces
{
    public interface IStateCheck
    {
        bool IsExecuting();
        bool IsPausing();
        void WaitPause();
    }
}
