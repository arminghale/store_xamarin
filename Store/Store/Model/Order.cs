using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Store
{
   public class Order : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int ID { get; set; }
        public int Total { get; set; }
        public int TotalWithoutTakhfif { get; set; }
        public bool IsComplete { get; set; }
        public bool ISCansel { get; set; }
        public string PhoneNumber { get; set; }

        public string TotalString
        {
            get
            {
                return Total.ToString("###/000") + "تومان";
            }
        }
        public string TotalWithoutTakhfifString
        {
            get
            {
                return "بدون احتساب تخفیف "+TotalWithoutTakhfif.ToString("###/000") + "تومان";
            }
        }

        public bool Cansel
        {
            get
            {
                if (IsComplete)
                {
                    return false;
                }
                else if (ISCansel)
                {
                    return false;
                }
                return true;
            }
        }
        public bool Complete
        {
            get
            {
                if (IsComplete)
                {
                    return false;
                }
                else if (ISCansel)
                {
                    return false;
                }
                return true;
            }
        }
        public string Vaziat
        {
            get
            {
                if (ISCansel)
                {
                    return "کنسل شده";
                }
                if (IsComplete)
                {
                    return "پرداخت شده";
                }
                return "تکمیل نشده";
            }
        }

    }
}
