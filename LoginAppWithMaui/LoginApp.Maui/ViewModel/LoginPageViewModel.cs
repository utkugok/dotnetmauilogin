using CommunityToolkit.Mvvm.ComponentModel;

namespace LoginApp.Maui.ViewModel;

public partial class LoginPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string _username;

    [ObservableProperty]
    private string _password;
}
