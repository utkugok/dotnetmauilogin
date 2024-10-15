using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LoginApp.Maui.ViewModel;

public partial class LoginPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string _username;

    [ObservableProperty]
    private string _password;

    [RelayCommand]
    public async void SignIn()
    {

    }
}
