using EshopKaze.Models;
using EshopKaze.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EshopKaze.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            loader.IsVisible = true;
            btnSubmit.IsEnabled = false;


            try
            {
                UserService service = new UserService(App.ServiceBaseAdress);
                var user = await service.CreateAsync(
                    new UserModel(
                        0,
                        txtUsername.Text, 
                        txtpassword.Text, 
                        txtFullname.Text, 
                        txtRole.Text)
                    );

                await DisplayAlert("information",
                    "User created with success",
                    "ok"
                    );

                    


            }
            catch (DuplicateWaitObjectException ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");


            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                await DisplayAlert("Bad", "Error of connexion", "ok");
            }

            loader.IsVisible = false;
            btnSubmit.IsEnabled = true;

        }

         
    }
}