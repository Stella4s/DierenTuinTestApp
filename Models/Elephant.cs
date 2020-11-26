using System;
using System.Collections.Generic;
using System.Text;

namespace DierenTuinTestApp.Models
{
    public sealed class Elephant : Animal
    {
        #region properties
        public override int EnergyPerTick => 5;
        public override int RequiredFoodAmount => 50;
        public override AnimalTypes Type => AnimalTypes.Elephant;
        #endregion

        public Elephant()
        {
            Name = "Elephant";
        }
    }
}
