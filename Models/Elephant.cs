using System;
using System.Collections.Generic;
using System.Text;

namespace DierenTuinWPF.Models
{
    public sealed class Elephant : Animal
    {
        #region properties
        public override int EnergyPerTick => 5;
        public override int RequiredFoodAmount => 50;
        public override AnimalTypes Type => AnimalTypes.Elephant;
        public override int MaxEnergy => 200;
        #endregion

        public Elephant()
        {
            Name = "Elephant";
        }
    }
}
