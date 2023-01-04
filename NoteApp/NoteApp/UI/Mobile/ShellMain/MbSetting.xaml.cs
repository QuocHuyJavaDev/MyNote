namespace NoteApp.UI.Mobile.ShellMain;

public partial class MbSetting : ContentPage
{
	public MbSetting()
	{
		InitializeComponent();
	}

    private void Logout_Click(object sender, EventArgs e)
    {
        if (Preferences.ContainsKey(nameof(App.userInfor)))
        {
            Preferences.Remove(nameof(App.userInfor));
        }
        Preferences.Clear();
        Application.Current.MainPage = new MbShell();
    }
}