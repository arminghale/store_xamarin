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
    public partial class Employees : ContentPage
    {
        public Employees()
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

            InventoryList.ItemsSource = Methods.GetEmployee();

            btn_add.Clicked += async (s, e) =>
            {
                string name = "";
                while (string.IsNullOrEmpty(name))
                {
                    name = await DisplayPromptAsync("اطلاعات کارمند", "لطفا نام شخص را وارد کنید.");
                }
                string lastname = "";
                while (string.IsNullOrEmpty(lastname))
                {
                    lastname = await DisplayPromptAsync("اطلاعات کارمند", "لطفا نام خانوادگی شخص را وارد کنید.");
                }
                string num = "";
                while (string.IsNullOrEmpty(num))
                {
                    num = await DisplayPromptAsync("اطلاعات کارمند", "لطفا شماره شخص را وارد کنید.");
                }
                string address = "";
                while (string.IsNullOrEmpty(address))
                {
                    address = await DisplayPromptAsync("اطلاعات کارمند", "لطفا آدرس شخص را وارد کنید.");
                }
                string code = "";
                while (string.IsNullOrEmpty(code))
                {
                    code = await DisplayPromptAsync("اطلاعات کارمند", "لطفا کد ملی شخص را وارد کنید.");
                }
                string bime = "";
                while (string.IsNullOrEmpty(bime))
                {
                    bime = await DisplayPromptAsync("اطلاعات کارمند", "لطفا شماره بیمه شخص را وارد کنید.");
                }
                Employee employee = new Employee
                {
                    ID = code,
                    Name = name,
                    Lastname = lastname,
                    Address = address,
                    BimeNumber = bime,
                    Number = num
                };
                Methods.SetEmployee(employee);
                await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
                await Navigation.PushAsync(new Employees());
            };

            
        }
        private async void btn_del(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            Methods.DeleteEmployee(id);
            await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
            await Navigation.PushAsync(new Employees());
        }
        private async void btn_update(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            string action = await DisplayActionSheet("انتخاب پارامتر", "Cancel", null, "نام", "نام خانوادگی", "شماره", "آدرس", "شماره بیمه");
            var employee= Methods.GetEmployee().FirstOrDefault(w => w.ID == id);
            switch (action)
            {
                case "نام":
                    string name = await DisplayPromptAsync("لطفا نام شخص را وارد کنید.", employee.Name);
                    if (!string.IsNullOrEmpty(name))
                    {
                        employee.Name = name;
                    }
                    break;
                case "نام خانوادگی":
                    string lastname = await DisplayPromptAsync("لطفا نام خانوادگی شخص را وارد کنید.", employee.Lastname);
                    if (!string.IsNullOrEmpty(lastname))
                    {
                        employee.Lastname = lastname;
                    }
                    break;
                case "شماره":
                    string num = await DisplayPromptAsync("لطفا شماره شخص را وارد کنید.", employee.Number);
                    if (!string.IsNullOrEmpty(num))
                    {
                        employee.Number = num;
                    }
                    break;
                case "آدرس":
                    string ad = await DisplayPromptAsync("لطفا آدرس شخص را وارد کنید.", employee.Address);
                    if (!string.IsNullOrEmpty(ad))
                    {
                        employee.Address = ad;
                    }
                    break;
                case "شماره بیمه":
                    string bime = await DisplayPromptAsync("لطفا شماره بیمه شخص را وارد کنید.", employee.BimeNumber);
                    if (!string.IsNullOrEmpty(bime))
                    {
                        employee.BimeNumber = bime;
                    }
                    break;
            }
            Methods.UpdateEmployee(employee);
            await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
            await Navigation.PushAsync(new Employees());
        }
        private async void btn_pay(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            var employee = Methods.GetEmployee().FirstOrDefault(w => w.ID == id);
            await Navigation.PushAsync(new Payment(employee));
        }
    }
}