using NoteApp.Models;
using NoteApp.UI.Mobile;
using NoteApp.UI.Desktop;

namespace NoteApp;

public partial class App : Application
{
    public static User userInfor;
    public App()
	{
		InitializeComponent();

#if ANDROID || IOS
        MainPage = new MbShell();
#else
        MainPage = new ShellBase();
#endif
    }
}
