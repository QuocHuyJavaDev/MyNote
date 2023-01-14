using NoteApp.UI.Desktop.MainDesktop;

namespace NoteApp.UI.Desktop;

public partial class ShellBase : Shell
{
	public ShellBase()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(DTHome), typeof(DTHome));
    }
}