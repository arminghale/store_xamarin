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
    public partial class Payment : ContentPage
    {
        public Payment(Employee employee)
        {
            InitializeComponent();
            InventoryList.ItemsSource = Methods.GetEmployee();
            name.Text = employee.namelast;

            InventoryList.ItemsSource = Methods.GetPaymentWithEmID(employee.ID);

            btn_add.Clicked += async (s, e) =>
            {
                string start = "";
                while (string.IsNullOrEmpty(start))
                {
                    start = await DisplayPromptAsync("اطلاعات پرداخت", "لطفا تاریخ شروع را وارد کنید."+ "( 15:20:10 20-01-1400)");
                }
                string end = "";
                while (string.IsNullOrEmpty(end))
                {
                    end = await DisplayPromptAsync("اطلاعات پرداخت", "لطفا تاریخ پایان را وارد کنید." + " ( 15:20:10 20-01-1400)");
                }
                string price = "";
                while (string.IsNullOrEmpty(price))
                {
                    price = await DisplayPromptAsync("اطلاعات پرداخت", "لطفا مبلغ را وارد کنید.");
                }
                string code = "";
                while (string.IsNullOrEmpty(code))
                {
                    code = await DisplayPromptAsync("اطلاعات پرداخت", "لطفا کد تراکنش را وارد کنید.");
                }
                Store.Payment payment = new Store.Payment
                {
                    ID=code,
                    Price=price,
                    EmployeeID=employee.ID
                };
                start = start.Replace('-', '/');
                payment.StartTime = DateTime.Parse(start, new CultureInfo("fa-IR"));
                end = end.Replace('-', '/');
                payment.EndTime = DateTime.Parse(end, new CultureInfo("fa-IR"));
                Methods.SetPayment(payment);
                await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
                await Navigation.PushAsync(new Payment(employee));
            };

            
        }
    }
}