using Store.Views;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Store
{
    public partial class App : Application
    {
        public static string ConnectionString = "Server=DESKTOP-BU142BU\\SQL2019;Database=Store;Trusted_Connection=True;MultipleActiveResultSets=true;";


        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Home());
        }
        

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
