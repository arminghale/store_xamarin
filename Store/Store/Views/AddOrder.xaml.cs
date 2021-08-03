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
    public partial class AddOrder : ContentPage
    {
        private int total = 0;
        private int total2 = 0;
        List<OrderItem> items = new List<OrderItem>();
        public AddOrder()
        {
            InitializeComponent();
            InventoryList.ItemsSource = Methods.GetProduct();

            btn_search.Clicked += (s, e) =>
            {
                InventoryList.ItemsSource = null;
                InventoryList.ItemsSource = Methods.GetProduct().Where(w => w.Name.Contains(search.Text) || w.ID.ToString().Contains(search.Text));
            };

            btn_sabt.Clicked += async (s, e) =>
             {
                 if (string.IsNullOrEmpty(Phone.Text))
                 {
                     await DisplayAlert("خطا!", "لطفا شماره همراه را وارد کنید.", "OK");
                 }
                 else
                 {
                     Store.Order order = new Store.Order
                     {
                         PhoneNumber = Phone.Text,
                         Total = total,
                         TotalWithoutTakhfif = total2
                     };
                     Methods.SetOrder(order);
                     int id = Methods.GetOrder().LastOrDefault().ID;
                     foreach (var item in items)
                     {
                         item.OrderID = id;
                         Methods.SetOrderItem(item);
                     }
                     await Navigation.PushAsync(new Order());
                 }
             };
        }

        private async void InventoryList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = ((Store.Product)e.Item);
            if (items.Any(w => w.ProductID == product.ID))
            {
                await DisplayAlert("خطا!", "این کالا قبلا ثبت شده است.", "OK");
            }
            else
            {
                var name = await DisplayPromptAsync("تعداد را وارد کنید", product.Count + "موجودی ");
                if (product.Count < int.Parse(name))
                {
                    await DisplayAlert("خطا!", "تعداد وارد شده بیش از موجودی است.", "OK");
                }
                else
                {
                    items.Add(new OrderItem { ProductID = product.ID, Count = int.Parse(name), Total = Methods.MablaghBaTakhfif(product) * int.Parse(name) });
                    InventoryList2.ItemsSource = null;
                    InventoryList2.ItemsSource = items;
                    total += Methods.MablaghBaTakhfif(product) * int.Parse(name);
                    total2 += product.Price * int.Parse(name);
                    Total.Text = total.ToString("###/000") + "تومان";
                    Total2.Text = "بدون احتساب تخفیف " + total2.ToString("###/000") + "تومان";
                    product.Count = product.Count - int.Parse(name);
                    Methods.UpdateProduct(product);
                }

            }

        }

        private void itemdel_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (OrderItem)e.Item;
            var product = Methods.GetProduct().FirstOrDefault(w => w.ID == item.ProductID);
            total -= item.Total;
            total2 -= item.Count * product.Price;
            product.Count += item.Count;
            Methods.UpdateProduct(product);
            items.Remove(item);
            InventoryList2.ItemsSource = null;
            InventoryList2.ItemsSource = items;
            Total.Text = total.ToString("###/000") + "تومان";
            Total2.Text = "بدون احتساب تخفیف " + total2.ToString("###/000") + "تومان";
        }
    }
}