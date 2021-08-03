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
    public partial class Home : ContentPage
    {
        public Home()
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
        }
    }
}