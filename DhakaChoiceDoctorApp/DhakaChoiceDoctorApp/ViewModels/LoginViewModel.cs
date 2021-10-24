using DhakaChoiceDoctorApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using DhakaChoiceDoctorApp.Services;
using Xamarin.Forms;

namespace DhakaChoiceDoctorApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public RegisterService RegisterService = new RegisterService();

        public string UserName { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await RegisterService.LoginAsync(UserName, Password);
                });
            }
        }

        //public ICommand RegisterCommand
        //{
        //    get
        //    {
        //        return new Command<Type>(async (Type pageType) =>
        //            {
        //                //RegisterPage page = (RegisterPage)Activator.CreateInstance(pageType);
        //                await Navigation.PushAsync(new RegisterPage());
        //            });
                
        //    }
        //}


        //public Command LoginCommand { get; }

        //public LoginViewModel()
        //{
        //    LoginCommand = new Command(OnLoginClicked);
        //}

        //private async void OnLoginClicked(object obj)
        //{
        //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        //    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        //}
    }
}
