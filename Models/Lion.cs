using System;
using System.Collections.Generic;
using System.Text;

namespace DierenTuinWPF.Models
{
    public sealed class Lion : Animal
    {
        #region properties
        public override int EnergyPerTick => 6;
        public override int RequiredFoodAmount => 25;
        public override AnimalTypes Type => AnimalTypes.Lion;
        public override int MaxEnergy => 250;
        #endregion

        public Lion()
        {
            Energy = 130;
            Name = "Lion";
        }
    }
}
