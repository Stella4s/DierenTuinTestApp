using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DierenTuinWPF.Models
{
    public class Message : INotifyPropertyChanged
    {
        private string _Text;
        private Urgency _Urgency;
        

        #region public properties
        public string Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
                OnPropertyChanged();
            }
        }
        public Urgency Urgency
        {
            get { return _Urgency; }
            set
            {
                _Urgency = value;
                OnPropertyChanged();
            }
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

    public enum Urgency
    {
        Low,
        Medium,
        High
    }
}
