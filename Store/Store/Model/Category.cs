using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Store
{
   public class Category : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int ID { get; set; }
        public string Title { get; set; }
    }
}
