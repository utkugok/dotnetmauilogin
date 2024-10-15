using LoginApp.Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Maui.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<User> Login(string email, string password)
        {
            try
            {
                var client = new HttpClient();
                string localhostUrl = $"https://localhost:7214/api/user/login/{email}";

                client.BaseAddress = new Uri(localhostUrl);
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                if(response.IsSuccessStatusCode)
                {
                    User user = await response.Content.ReadFromJsonAsync<User>();

                    return await Task.FromResult(user);
                }

                return null;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");

                return null;
            }
           
        }
    }
}
