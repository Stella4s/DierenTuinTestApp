using System;
using System.Collections.Generic;
using System.Text;

namespace DierenTuinTestApp.Models
{
    public sealed class Monkey : Animal
    {
        #region properties
        public override int EnergyPerTick => 2;
        public override int RequiredFoodAmount => 10;
        #endregion

        public Monkey()
        {
            Energy = 60;
        }

    }
}
