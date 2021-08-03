using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Store
{
   public class Takhfif : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int ID { get; set; }
        public int ProductID { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public int Darsad { get; set; }
        public bool ActiveBool { get; set; }
        public string Active
        {
            get
            {
                if (DateDifference.IsActive(EndTime))
                {
                    ActiveBool = true;
                    return "فعال";
                }
                ActiveBool = false;
                return "اتمام زمان تخفیف";
            }
        }

        public string startstring
        {
            get
            {
                return DateDifference.MiladiToShamsi(StartTime);
            }
        }
        public string endstring
        {
            get
            {
                return DateDifference.MiladiToShamsi(EndTime);
            }
        }
    }
}
