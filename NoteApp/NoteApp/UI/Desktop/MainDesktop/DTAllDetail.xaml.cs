using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using NoteApp.Models;
using NoteApp.Service;
using NoteApp.ViewModels;

namespace NoteApp.UI.Desktop.MainDesktop;

public partial class DTAllDetail : ContentPage
{
    private INote _noteSer = new NoteVM();
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    ToastDuration duration = ToastDuration.Short;
    double fontSize = 14;
    public DTAllDetail()
	{
		InitializeComponent();
        entryTit.Text = DTAllNote.noteData.NoteName;
        TextEditor.Text = DTAllNote.noteData.NoteDetail;
        int isFavor = DTAllNote.noteData.IsFavor;
        if (isFavor == 0)
        {
            btnFavor.IsEnabled = false;
            btnFavor.IsVisible = false;
            btnUnfavor.IsEnabled = true;
            btnUnfavor.IsVisible = true;
        }
        else if (isFavor == 1)
        {
            btnFavor.IsEnabled = true;
            btnFavor.IsVisible = true;
            btnUnfavor.IsEnabled = false;
            btnUnfavor.IsVisible = false;
        }
    }

    private async void Save_Click(object sender, EventArgs e)
    {
        string nName = entryTit.Text;
        string nDetail = TextEditor.Text;
        string getDate = DateTime.Now.ToString("dd/MM/yyyy");
        int userid = App.userInfor.UserId;
        int ntbId = DTAllNote.noteData.NByNtb;
        int noteid = DTAllNote.noteData.NoteId;
        Note note = new Note
        {
            NoteName = nName,
            NoteDetail = nDetail,
            DateAddUp = getDate,
            IsFavor = 0,
            NByNtb = ntbId,
            NByUser = userid
        };
        bool check = await _noteSer.UpdNote(noteid, note);
        if (check == true)
        {

            string text = "Saved";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
        else
        {
            string text = "Failed";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }

    private async void favor_Click(object sender, EventArgs e)
    {
        int noteid = DTAllNote.noteData.NoteId;
        Note note = new Note
        {
            NoteName = "",
            NoteDetail = "",
            DateAddUp = "",
            IsFavor = 0,
            NByNtb = 0,
            NByUser = 0
        };
        bool check = await _noteSer.FavorChange(noteid, note);
        if (check == true)
        {
            btnFavor.IsEnabled = false;
            btnFavor.IsVisible = false;
            btnUnfavor.IsEnabled = true;
            btnUnfavor.IsVisible = true;
            string text = "Unfavorited!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);

        }
        else
        {
            string text = "Failed!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }

    private async void unfavor_Click(object sender, EventArgs e)
    {
        int noteid = DTAllNote.noteData.NoteId;
        Note note = new Note
        {
            NoteName = "",
            NoteDetail = "",
            DateAddUp = "",
            IsFavor = 1,
            NByNtb = 0,
            NByUser = 0
        };
        bool check = await _noteSer.FavorChange(noteid, note);
        if (check == true)
        {
            string text = "Favorited!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
            btnFavor.IsEnabled = true;
            btnFavor.IsVisible = true;
            btnUnfavor.IsEnabled = false;
            btnUnfavor.IsVisible = false;
        }
        else
        {
            string text = "Failed!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }

    private void Delete_Click(object sender, EventArgs e)
    {

    }
}