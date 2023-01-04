using NoteApp.Models;
using NoteApp.Service;
using NoteApp.ViewModels;
using Syncfusion.Maui.Scheduler;
using NoteApp.UI.Desktop.DTPopup;
using System.Collections.ObjectModel;

namespace NoteApp.UI.Desktop.MainDesktop;

public partial class DTSchedule : ContentPage
{
    public ObservableCollection<SchedulerAppointment> ScheduleEvents { get; set; }
    private readonly ISchedule _scheService = new ScheduleVM();
    public DTSchedule()
	{
		InitializeComponent();
        this.ScheduleEvents = new ObservableCollection<SchedulerAppointment>();
        EventList();
        scheData.AppointmentsSource = ScheduleEvents;
    }
    private async void EventList()
    {
        ScheduleEvents.Clear();
        int userid = App.userInfor.UserId;
        List<Schedule> list = await _scheService.GetScheList(userid);
        for (int i = list.Count - 1; i >= 0; i--)
        {
            string[] getStart = list[i].EventStart.Split(' ');
            string[] getEnd = list[i].EventEnd.Split(' ');
            ScheduleEvents.Add(new SchedulerAppointment
            {
                StartTime = new DateTime(int.Parse(getStart[0]), int.Parse(getStart[1]), int.Parse(getStart[2]),
                int.Parse(getStart[3]), int.Parse(getStart[4]), int.Parse(getStart[5])),
                EndTime = new DateTime(int.Parse(getEnd[0]), int.Parse(getEnd[1]), int.Parse(getEnd[2]),
                int.Parse(getEnd[3]), int.Parse(getEnd[4]), int.Parse(getEnd[5])),
                Subject = list[i].EventName,
                Notes = list[i].EventId.ToString(),
                Background = Color.Parse("#C664BE")
            });
        }
    }
    private async void AddNtb_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DTAddEvent());
    }
    public static SchedulerAppointment saData;
    private async void Tap_Events(object sender, Syncfusion.Maui.Scheduler.SchedulerTappedEventArgs e)
    {
        if (e.Appointments != null)
        {
            var appointments = e.Appointments;
            SchedulerAppointment[] arr = new SchedulerAppointment[appointments.Count];
            appointments.CopyTo(arr, 0);
            saData = arr[0];
            await Navigation.PushAsync(new DTEditEvent());
        }
        else
        {
            await DisplayAlert("Event", $"No event", "Ok");
        }
    }
}