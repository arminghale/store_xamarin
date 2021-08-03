using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Store
{
   public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string BimeNumber { get; set; }

        public string namelast
        {
            get
            {
                return Name + " " + Lastname;
            }
        }
    }
}
