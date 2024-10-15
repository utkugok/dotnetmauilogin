using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginApp.Maui.Models;
using LoginApp.Maui.Services;
using LoginApp.Maui.Views;
using Newtonsoft.Json;

namespace LoginApp.Maui.ViewModels
{

    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _username;

        //[ObservableProperty]
        //private string _email;

        [ObservableProperty]
        private string _password;

        readonly ILoginRepository loginService = new LoginService();

        [RelayCommand]
        public async void SignIn()
        {
            //to check if internet connection is active
            //if(Connectivity.Current.NetworkAccess == NetworkAccess.Internet)

            try
            {
                if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
                {
                    User user = await loginService.Login(Username, Password);

                    if (user != null)
                    {
                        if (Preferences.ContainsKey(nameof(App.user)))
                        {
                            Preferences.Remove(nameof(App.user));
                        }

                        string userDetails = JsonConvert.SerializeObject(user);
                        Preferences.Set(nameof(App.user), userDetails);
                        App.user = user;

                        await Shell.Current.GoToAsync(nameof(HomePage));
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Email/password is incorrect", "Ok");
                        return;
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "All fields required", "Ok");
                    return;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return;
            }

        }
    }
}