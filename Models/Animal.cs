using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DierenTuinTestApp.Models
{
    public abstract class Animal : INotifyPropertyChanged
    {
        #region private properties
        private string _Name;
        private int _Energy;
        private static readonly int EnergyIncrease = 25;
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
                _Energy = value;
                OnPropertyChanged();
            }
        }
        public abstract int EnergyPerTick { get; }
        public abstract int RequiredFoodAmount { get; }
        public abstract AnimalTypes Type { get; }
        #endregion

        public Animal()
        {
            Energy = 100;
        }

        public void Eat()
        {
            Energy += EnergyIncrease;
        }
        public void UseEnergy()
        {
            Energy -= EnergyPerTick;
        }

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
