using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using NoteApp.Models;
using NoteApp.Service;
using NoteApp.UI.Mobile.ShellMain;
using NoteApp.ViewModels;
using System.Xml.Linq;

namespace NoteApp.UI.Mobile.PopupView;

public partial class EditNtb : ContentPage
{
    private readonly INotebook _ntbService = new NotebookVM();
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    ToastDuration duration = ToastDuration.Short;
    double fontSize = 14;
    public EditNtb()
	{
		InitializeComponent();
        txtNtbName.Text = MbNotebook.ntb2.NotebookName;
	}

    private async void back_click(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void Done_Click(object sender, EventArgs e)
    {
        string ntbName = txtNtbName.Text;
        string getDate = DateTime.Now.ToString("dd/MM/yyyy");
        int userid = App.userInfor.UserId;
        int ntbId = MbNotebook.ntb2.NotebookId;
        Notebook notebook = new Notebook
        {
            NotebookName = ntbName,
            DateCreate = getDate,
            ByUser = userid
        };
        bool check = await _ntbService.UpdNtb(ntbId, notebook);
        if (check == true)
        {
            await Navigation.PushAsync(new MbNotebook());
            string text = "Change Successfully!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
        else
        {
            string text = "Change Failed!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }
}