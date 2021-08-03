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
    public partial class Product : ContentPage
    {
        public Product()
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

            InventoryList.ItemsSource = Methods.GetProduct();

            btn_add.Clicked += async (s, e) =>
            {
                string name = "";
                while (string.IsNullOrEmpty(name))
                {
                    name = await DisplayPromptAsync("اطلاعات کالا", "لطفا نام کالا را وارد کنید.");
                }
                string company = "";
                while (string.IsNullOrEmpty(company))
                {
                    company = await DisplayPromptAsync("اطلاعات کالا", "لطفا نام شرکت سازنده کالا را وارد کنید.");
                }
                string code = "";
                while (string.IsNullOrEmpty(code))
                {
                    code = await DisplayPromptAsync("اطلاعات کالا", "لطفا کد کالا را وارد کنید.");
                }
                string count = "";
                while (string.IsNullOrEmpty(count))
                {
                    count = await DisplayPromptAsync("اطلاعات کالا", "لطفا تعداد کالا را وارد کنید.");
                }
                string price = "";
                while (string.IsNullOrEmpty(price))
                {
                    price = await DisplayPromptAsync("اطلاعات کالا", "لطفا قیمت کالا به تومان را وارد کنید.");
                }
                int catid = 0;
                List<string> list = new List<string>();
                foreach (var item in Methods.GetCategory())
                {
                    list.Add(item.Title);
                }
                string action = "";
                while (string.IsNullOrEmpty(action))
                {
                     action = await DisplayActionSheet("انتخاب دسته محصول", "Cancel", null, list.ToArray());
                }
                foreach (var item in Methods.GetCategory())
                {
                    if (item.Title==action)
                    {
                        catid = item.ID;
                    }
                }


                Store.Product product = new Store.Product
                {
                    ID = int.Parse(code),
                    Name = name,
                    Company = company,
                    Count = int.Parse(count),
                    Price = int.Parse(price),
                    CategoryID = catid
                };
                Methods.SetProduct(product);
                await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
                await Navigation.PushAsync(new Product());
            };

            
        }
        private async void btn_del(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            Methods.DeleteProduct(int.Parse(id));
            await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
            await Navigation.PushAsync(new Product());
        }
        private async void btn_update(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            string action = await DisplayActionSheet("انتخاب پارامتر", "Cancel", null, "نام", "نام شرکت", "تعداد", "قیمت", "دسته بندی");
            var product= Methods.GetProduct().FirstOrDefault(w => w.ID == int.Parse(id));
            switch (action)
            {
                case "نام":
                    string name = await DisplayPromptAsync("لطفا نام کالا را وارد کنید.", product.Name);
                    if (!string.IsNullOrEmpty(name))
                    {
                        product.Name = name;
                    }
                    break;
                case "نام شرکت":
                    string lastname = await DisplayPromptAsync("لطفا نام شرکت کالا را وارد کنید.", product.Company);
                    if (!string.IsNullOrEmpty(lastname))
                    {
                        product.Company = lastname;
                    }
                    break;
                case "تعداد":
                    string num = await DisplayPromptAsync("لطفا تعداد کالا را وارد کنید.", product.Count.ToString());
                    if (!string.IsNullOrEmpty(num))
                    {
                        product.Count = int.Parse(num);
                    }
                    break;
                case "قیمت":
                    string ad = await DisplayPromptAsync("لطفا قیمت کالا را وارد کنید.", product.Price.ToString());
                    if (!string.IsNullOrEmpty(ad))
                    {
                        product.Price = int.Parse(ad);
                    }
                    break;
                case "دسته بندی":
                    int catid = 0;
                    string now = "";
                    List<string> list = new List<string>();
                    foreach (var item in Methods.GetCategory())
                    {
                        list.Add(item.Title);
                        if (product.CategoryID==item.ID)
                        {
                            now = item.Title;
                        }
                    }
                    string action2 = "";
                    while (string.IsNullOrEmpty(action))
                    {
                        action2 = await DisplayActionSheet("دسته فعلی: "+now, "Cancel", null, list.ToArray());
                    }
                    foreach (var item in Methods.GetCategory())
                    {
                        if (item.Title == action)
                        {
                            catid = item.ID;
                        }
                    }
                    product.CategoryID = catid;
                    break;
            }
            Methods.UpdateProduct(product);
            await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
            await Navigation.PushAsync(new Product());
        }
        private async void btn_pay(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            var employee = Methods.GetProduct().FirstOrDefault(w => w.ID == int.Parse(id));
            await Navigation.PushAsync(new Takhfif(employee));
        }
    }
}