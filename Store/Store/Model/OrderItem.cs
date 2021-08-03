using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Store
{
   public class OrderItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int ID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }

        public string TotalString
        {
            get
            {
                return Total.ToString("###/000");
            }
        }

        public string ProductName
        {
            get
            {
                return Methods.GetProduct().FirstOrDefault(w => w.ID == ProductID).Name;
            }
        }
    }
}
