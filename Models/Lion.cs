using System;
using System.Collections.Generic;
using System.Text;

namespace DierenTuinTestApp.Models
{
    public sealed class Lion : Animal
    {
        #region properties
        public override int EnergyPerTick => 10;
        public override int RequiredFoodAmount => 25;
        #endregion
    }
}
