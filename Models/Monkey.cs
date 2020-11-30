using System;
using System.Collections.Generic;
using System.Text;

namespace DierenTuinWPF.Models
{
    public sealed class Monkey : Animal
    {
        #region properties
        public override int EnergyPerTick => 3;
        public override int RequiredFoodAmount => 10;
        public override AnimalTypes Type => AnimalTypes.Monkey;
        public override int MaxEnergy => 120;
        #endregion

        public Monkey()
        {
            Energy = 60;
            Name = "Monkey";
        }

    }
}
