using System;
using System.Collections.Generic;
using System.Text;

namespace DierenTuinWPF.Models
{
    public sealed class Lion : Animal
    {
        #region properties
        public override int EnergyPerTick => 10;
        public override int RequiredFoodAmount => 25;
        public override AnimalTypes Type => AnimalTypes.Lion;
        public override int MaxEnergy => 400;
        #endregion

        public Lion()
        {
            Energy = 150;
            Name = "Lion";
        }
    }
}
