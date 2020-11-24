using DierenTuinTestApp.Models;
using DierenTuinTestApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DierenTuinTestApp.ViewModels
{
    public class AnimalMainViewModel : BaseViewModel
    {
        #region private properties

        #endregion

        #region public properties
        public ObservableCollection<Animal> Animals;
        #endregion

        public AnimalMainViewModel()
        {
            Animals = new ObservableCollection<Animal>();
        }

    }
}
