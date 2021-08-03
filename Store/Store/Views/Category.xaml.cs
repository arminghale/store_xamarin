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
    public partial class Category : ContentPage
    {
        public Category()
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

            InventoryList.ItemsSource = Methods.GetCategory();

            btn_add.Clicked += async (s, e) =>
            {
                string title = "";
                while (string.IsNullOrEmpty(title))
                {
                    title = await DisplayPromptAsync("اطلاعات دسته محصولات", "لطفا عنوان دسته را وارد کنید.");
                }
                Store.Category category = new Store.Category
                {
                    Title=title
                };
                Methods.SetCategory(category);
                await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
                await Navigation.PushAsync(new Category());
            };

            
        }
        private async void btn_del(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            Methods.DeleteCategory(int.Parse(id));
            await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
            await Navigation.PushAsync(new Category());
        }
        private async void btn_update(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var grid = (Grid)but.Parent.Parent;
            var Label = (Label)grid.Children[0];
            var id = Label.ClassId;
            var category= Methods.GetCategory().FirstOrDefault(w => w.ID == int.Parse(id));
            string title = "";
            title = await DisplayPromptAsync(category.Title, "لطفا عنوان دسته را وارد کنید.");
            if (!string.IsNullOrEmpty(title))
            {
                category.Title = title;
            }
            Methods.UpdateCategory(category);
            await DisplayAlert("موفق!", "با موفقیت انجام شد.", "تایید");
            await Navigation.PushAsync(new Category());
        }
    }
}