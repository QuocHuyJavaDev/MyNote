using NoteApp.UI.Mobile.ShellMain;

namespace NoteApp.UI.Mobile;

public partial class MbShell : Shell
{
	public MbShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(MbHome), typeof(MbHome));
       // Routing.RegisterRoute(nameof(MbNotebook), typeof(MbNotebook));
    }
}