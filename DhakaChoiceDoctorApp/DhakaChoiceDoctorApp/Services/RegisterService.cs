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
            var client = new HttpClient();

            var model = new RegisterViewModel
            {
                PhoneNumber = phoneNumber,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://dhakachoice.com/api/doctoraccount",content);

            return response.IsSuccessStatusCode;
        }

        public async Task LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44328/api/DoctorAccount/Register");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(content);
        }
    }
}
