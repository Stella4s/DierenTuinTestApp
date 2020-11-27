using System;
using System.Collections.Generic;
using System.Text;

namespace DierenTuinWPF.Models
{
    public sealed class Monkey : Animal
    {
        #region properties
        public override int EnergyPerTick => 2;
        public override int RequiredFoodAmount => 10;
        public override AnimalTypes Type => AnimalTypes.Monkey;
        #endregion

        public Monkey()
        {
            Energy = 60;
            Name = "Monkey";
        }

    }
}
