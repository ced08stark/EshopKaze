using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using EshopKaze.Service;
using Xamarin.Forms;

namespace EshopKaze.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

       
        private async void Button_Clicked_1(object sender, EventArgs e)
        {

           
            loader.IsVisible = true;
            btn_connect.IsEnabled = false;
            try
            {
                UserService service = new UserService(App.ServiceBaseAdress);
                var user = await service.LoginAsync(txt_name.Text, txt_password.Text);
                await DisplayAlert("Good", user.Fullname, "ok");
                await Navigation.PushAsync(new RegisterPage());
            }
            catch (UnauthorizedAccessException ex)
            {
                await DisplayAlert("Bad", ex.Message, "ok");
            
                
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                await DisplayAlert("Bad", "Error of connexion", "ok");
            }

            loader.IsVisible = false;
            btn_connect.IsEnabled = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
