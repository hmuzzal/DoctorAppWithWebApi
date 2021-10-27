using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DhakaChoiceDoctorApp.ViewModels;
using Newtonsoft.Json;

namespace DhakaChoiceDoctorApp.Services
{
    public class RegisterService
    {
        public async Task<bool> RegisterAsync(string phoneNumber, string password, string confirmPassword)
        {
            //if (password != confirmPassword)
            //{
            //    displayal
            //}
            var client = new HttpClient();

            var model = new RegisterViewModel
            {
                PhoneNumber = phoneNumber,
                Password = password
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://openpi.dhakachoice.com/api/DoctorAccount/register",content);

            return response.IsSuccessStatusCode;
        }

        public async Task LoginAsync(string userName, string password)
        {
            var model = new LoginViewModel
            {
                UserName = userName,
                Password = password
            };

            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = await client.PostAsync("https://openpi.dhakachoice.com/api/DoctorAccount/Login", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            //var keyValues = new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("username", userName),
            //    new KeyValuePair<string, string>("password", password)
            //    //new KeyValuePair<string, string>("grant_type", "password")
            //};

            //var request = new HttpRequestMessage(HttpMethod.Post, "https://openpi.dhakachoice.com/api/DoctorAccount/Login");

            //request.Content = new FormUrlEncodedContent(model);

      
            //var response = await client.SendAsync(model); 
            //var content = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseBody);
        }
    }
}
