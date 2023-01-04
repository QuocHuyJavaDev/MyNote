using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using NoteApp.Models;
using NoteApp.Service;
using NoteApp.ViewModels;

namespace NoteApp.UI.Mobile.LogRegIntr;

public partial class MbRegister : ContentPage
{
    private readonly IUser _userSevice = new UserVM();
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    ToastDuration duration = ToastDuration.Short;
    double fontSize = 14;
    public MbRegister()
	{
		InitializeComponent();
	}

    private async void Register_Click(object sender, EventArgs e)
    {
        string userName = txtUserName.Text;
        string password = txtPassword.Text;
        string rePassword = txtRePassword.Text;
        if (userName == null || password == null || rePassword == null)
        {
            string text = "Please input Username & Password";
            //await DisplayAlert("Warning", "Please input Username & Password", "OK");
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
            return;
        }
        if (password != rePassword)
        {
            string text = "Password does not match!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
            return;
        }
        User user = new User{
            UserName= userName,
            UserPass = password
        };
        bool check = await _userSevice.Register(user);
        if (check == true)
        {
            await Navigation.PushAsync(new Intro());
            string text = "Register Successfully!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
        else
        {
            string text = "Something went wrong!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }

    private async void back_click(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void Signin_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MbLogin());
    }
}