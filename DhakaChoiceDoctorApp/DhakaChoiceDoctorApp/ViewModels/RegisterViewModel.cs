using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using DhakaChoiceDoctorApp.Services;
using Xamarin.Forms;

namespace DhakaChoiceDoctorApp.ViewModels
{
    public class RegisterViewModel
    {
        private readonly RegisterService _registerService = new RegisterService();
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _registerService.RegisterAsync(PhoneNumber, Password, ConfirmPassword);
                });
            }
        }

    }
}
