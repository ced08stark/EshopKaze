using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EshopKaze.Mobile
{
    public partial class App : Application
    {

        static public string ServiceBaseAdress = String.Empty;
        public App()
        {
            InitializeComponent();

            if (DeviceInfo.DeviceType == DeviceType.Virtual)
                ServiceBaseAdress = "http://10.0.0.1/";
            else
                ServiceBaseAdress = "http://192.168.43.254:8180/api/";

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
