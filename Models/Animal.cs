using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DierenTuinWPF.Models
{
    public abstract class Animal : INotifyPropertyChanged
    {
        #region private properties
        private string _Name;
        private int _Energy;
        private int _RelativeEnergy;
        private static readonly int EnergyIncrease = 25;
        private bool FiredIsStarving;
        #endregion

        #region public properties
        public string Name 
        { 
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        public int Energy
        {
            get { return _Energy; }
            set
            {
                if (value > MaxEnergy)
                    value = MaxEnergy;
                _Energy = value;
                OnPropertyChanged();
            }
        }
        public int RelativeEnergy
        {
            get { return _RelativeEnergy; }
            set
            {
                _RelativeEnergy = value;
                OnPropertyChanged();
            }
        }
        public abstract int MaxEnergy { get; }
        public abstract int EnergyPerTick { get; }
        public abstract int RequiredFoodAmount { get; }
        public abstract AnimalTypes Type { get; }
        #endregion

        public Animal()
        {
            Energy = 100;
            GetRelativeEnergy();
            FiredIsStarving = false;
        }

        public void Eat()
        {
            Energy += EnergyIncrease;
            GetRelativeEnergy();

            //Check if animal still is starving. Reset FiredIsStarving.
            if (!(RelativeEnergy <= 15))
                FiredIsStarving = false;          
        }
        public void UseEnergy()
        {
            Energy -= EnergyPerTick;
            GetRelativeEnergy();

            if (Energy <= 0)
                OnHasDied(EventArgs.Empty);
            if (RelativeEnergy <= 15)
                OnIsStarving(EventArgs.Empty);
        }
        private void GetRelativeEnergy()
        {
            RelativeEnergy = (int)((double)Energy / MaxEnergy * 100);
        }

        #region events
        public event EventHandler IsStarving;
        protected void OnIsStarving(EventArgs e)
        {
            EventHandler handler = IsStarving;

            //Check if FiredIsStarving true, to prevent repeat firing IsStarving.
            if ((handler != null) && !FiredIsStarving)
            {
                FiredIsStarving = true;
                handler(this, e);
            }
        }
        public event EventHandler HasDied;
        protected void OnHasDied(EventArgs e)
        {
            HasDied?.Invoke(this, e);
        }
        #endregion

        #region INotifyPropertyChanged Members  
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public enum AnimalTypes
    {
        Monkey,
        Lion,
        Elephant
    }
}
