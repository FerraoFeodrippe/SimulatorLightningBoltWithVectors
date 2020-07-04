using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLightningBoltWithVectors.Interfaces
{
    public interface IStateCheck
    {
        bool IsExecuting();
        bool IsPausing();
        void WaitPause();
    }
}
