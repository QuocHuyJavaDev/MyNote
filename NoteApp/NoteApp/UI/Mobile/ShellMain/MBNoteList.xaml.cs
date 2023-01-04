using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using NoteApp.Models;
using NoteApp.Service;
using NoteApp.ViewModels;
using System.Collections.ObjectModel;

namespace NoteApp.UI.Mobile.ShellMain;

public partial class MBNoteList : ContentPage
{
    public ObservableCollection<Note> noteByNtb { get; set; }
    private readonly INote _noteService = new NoteVM();
    public static Note noteData;
    //
    ObservableCollection<Note> updateList { get; set; } = new ObservableCollection<Note>();
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    ToastDuration duration = ToastDuration.Short;
    double fontSize = 14;
    public MBNoteList()
	{
		InitializeComponent();
        lbNtbName.Text = MbNotebook.ntb2.NotebookName;
        noteByNtb = new ObservableCollection<Note>();
        NoteByNtb();
        noteView.ItemsSource= noteByNtb;
        BindingContext = this;
	}
    private async void NoteByNtb()
    {
        noteByNtb.Clear();
        int ntbid = MbNotebook.ntb2.NotebookId;
        List<Note> list = await _noteService.GetByNtbId(ntbid);
        for (int i = list.Count - 1; i >= 0; i--)
        {
            noteByNtb.Add(list[i]);
        }

    }
    private async void back_click(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void Add_Click(object sender, EventArgs e)
    {
        string getDate = DateTime.Now.ToString("dd/MM/yyyy");
        int ntbid = MbNotebook.ntb2.NotebookId;
        int userid = App.userInfor.UserId;
        Note note = new Note
        {
            NoteName = "Title",
            NoteDetail = "Write more...",
            DateAddUp = getDate,
            IsFavor = 0,
            NByNtb = ntbid,
            NByUser = userid
        };
        bool check = await _noteService.AddNote(note);
        if (check == true)
        {
            updateList.Clear();
            List<Note> listUp = await _noteService.GetByNtbId(ntbid);
            for (int i = listUp.Count - 1; i >= 0; i--)
            {
                updateList.Add(listUp[i]);
            }
            noteView.ItemsSource = updateList;
            string text = "Add Note Successfully!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
        else
        {
            string text = "Add Note Failed!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }

    private async void Search_TC(object sender, TextChangedEventArgs e)
    {
        int ntbid = MbNotebook.ntb2.NotebookId;
        List<Note> listntb = new List<Note>();
        listntb.Clear();
        listntb = await _noteService.GetByNtbId(ntbid);
        var result = listntb.Where(a => a.NoteName.StartsWith(e.NewTextValue));
        noteView.ItemsSource = result;
    }

    private async void Detai_Click(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        var ntb = (Note)btn.BindingContext;

        noteData = ntb;
        await Navigation.PushAsync(new MbNDetail());
    }
}