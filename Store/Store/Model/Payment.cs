using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Store
{
   public class Payment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ID { get; set; }
        public string EmployeeID { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string Price { get; set; }

        public string startstring
        {
            get
            {
                return DateDifference.MiladiToShamsi(StartTime).Split(' ')[0];
            }
        }
        public string endstring
        {
            get
            {
                return DateDifference.MiladiToShamsi(EndTime).Split(' ')[0];
            }
        }

        public string pricestring
        {
            get
            {
                return int.Parse(Price).ToString("#####/000") + "تومان";
            }
        }
    }
}
