using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Store.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Faktor : ContentPage
    {
        public Faktor(Store.Order order)
        {
            InitializeComponent();
            InventoryList2.ItemsSource = Methods.GetOrderItemWithOID(order.ID);

            Phone.Text = order.PhoneNumber;
            Total.Text = order.TotalString;
            Total2.Text = order.TotalWithoutTakhfifString;
            Vaziat.Text = order.Vaziat;
        }
    }
}