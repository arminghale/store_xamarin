using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Store.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Order : ContentPage
    {
        public Order()
        {
            InitializeComponent();
            btn_em.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new Employees());
            };
            btn_cat.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new Category());
            };
            btn_pr.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new Product());
            };
            btn_or.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new Order());
            };

            InventoryList.ItemsSource = Methods.GetOrder();

            btn_add.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new AddOrder());
            };

            btn_search.Clicked += (s, e) =>
            {
                InventoryList.ItemsSource = null;
                InventoryList.ItemsSource = Methods.GetOrder().Where(w=>w.PhoneNumber.Contains(search.Text));
            };

        }
        private async void btn_del(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            foreach (var item in Methods.GetOrderItemWithOID(int.Parse(id)))
            {
                var product = Methods.GetProduct().FirstOrDefault(w => w.ID == item.ID);
                product.Count += item.Count;
                Methods.UpdateProduct(product);
            }
            Methods.DeleteOrder(int.Parse(id));
            await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
            await Navigation.PushAsync(new Order());
        }
        private async void btn_pay(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            var order = Methods.GetOrder().FirstOrDefault(w => w.ID == int.Parse(id));
            order.IsComplete = true;
            Methods.UpdateOrder(order);
            await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
            await Navigation.PushAsync(new Order());
        }
        private async void btn_cansel(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            var order = Methods.GetOrder().FirstOrDefault(w => w.ID == int.Parse(id));
            order.ISCansel = true;
            Methods.UpdateOrder(order);
            foreach (var item in Methods.GetOrderItemWithOID(order.ID))
            {
                var product = Methods.GetProduct().FirstOrDefault(w => w.ID == item.ID);
                product.Count += item.Count;
                Methods.UpdateProduct(product);
            }
            await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
            await Navigation.PushAsync(new Order());
        }
        private async void btn_faktor(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            var order = Methods.GetOrder().FirstOrDefault(w => w.ID == int.Parse(id));
            await Navigation.PushAsync(new Faktor(order));
        }
    }
}