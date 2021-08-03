using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Store
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int Price { get; set; }
        public string PriceString { get { return Price.ToString("###/000"); } }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }

        public string CategoryString { 
            get { 
                return Methods.GetCategory().FirstOrDefault(w=>w.ID==CategoryID).Title; 
            }
        }

        public string PriceWithTakhfifString
        {
            get
            {
                var takhfif = Methods.GetTakhfifWithPrID(ID).OrderByDescending(w => w.EndTime).FirstOrDefault();
                if (takhfif != null)
                {
                    if (System.DateTime.Now < takhfif.EndTime && System.DateTime.Now > takhfif.StartTime)
                    {
                        double first = ((100.0 - takhfif.Darsad) / 100.0);
                        double mablagh = first * (Price);
                        return mablagh.ToString("###/000")+"با تخفیف";
                    }
                }
                return null;
            }
        }

        public int PriceWithTakhfif
        {
            get
            {
                var takhfif = Methods.GetTakhfifWithPrID(ID).OrderByDescending(w=>w.EndTime).FirstOrDefault();
                if (takhfif != null)
                {
                    if (System.DateTime.Now < takhfif.EndTime && System.DateTime.Now > takhfif.StartTime)
                    {
                        double first = ((100.0 - takhfif.Darsad) / 100.0);
                        double mablagh = first * (Price);
                        return int.Parse(mablagh.ToString());
                    }
                }
                return Price;
            }
        }

    }
}
