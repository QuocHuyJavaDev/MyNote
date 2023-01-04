namespace NoteApp.UI.Desktop.MainDesktop;

public partial class DTAccount : ContentPage
{
	public DTAccount()
	{
		InitializeComponent();
	}

    private void Signout_Click(object sender, EventArgs e)
    {
        if (Preferences.ContainsKey(nameof(App.userInfor)))
        {
            Preferences.Remove(nameof(App.userInfor));
        }
        Preferences.Clear();
        Application.Current.MainPage = new ShellBase();
    }
}