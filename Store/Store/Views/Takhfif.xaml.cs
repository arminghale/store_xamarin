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
    public partial class Takhfif : ContentPage
    {
        Store.Product product2 = null;
        public Takhfif(Store.Product product)
        {
            product2 = product;
            InitializeComponent();
            InventoryList.ItemsSource = Methods.GetEmployee();
            name.Text = "کالای "+product.ID.ToString();

            InventoryList.ItemsSource = Methods.GetTakhfifWithPrID(product.ID);

            btn_add.Clicked += async (s, e) =>
            {
                string start = "";
                while (string.IsNullOrEmpty(start))
                {
                    start = await DisplayPromptAsync("اطلاعات تخفیف", "لطفا تاریخ شروع را وارد کنید."+ "( 15:20:10 20-01-1400)");
                }
                string end = "";
                while (string.IsNullOrEmpty(end))
                {
                    end = await DisplayPromptAsync("اطلاعات تخفیف", "لطفا تاریخ پایان را وارد کنید." + " ( 15:20:10 20-01-1400)");
                }
                string price = "";
                while (string.IsNullOrEmpty(price))
                {
                    price = await DisplayPromptAsync("اطلاعات تخفیف", "لطفا درصد را وارد کنید.");
                }
                Store.Takhfif payment = new Store.Takhfif
                {
                    Darsad=int.Parse(price),
                    ProductID=product.ID
                };
                start = start.Replace('-', '/');
                payment.StartTime = DateTime.Parse(start, new CultureInfo("fa-IR"));
                end = end.Replace('-', '/');
                payment.EndTime = DateTime.Parse(end, new CultureInfo("fa-IR"));
                Methods.SetTakhfif(payment);
                await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
                await Navigation.PushAsync(new Takhfif(product));
            };
        }
        private async void btn_del(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            Methods.DeleteTakhfif(int.Parse(id));
            await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
            await Navigation.PushAsync(new Takhfif(product2));
        }
    }
}