namespace BlazorApp.Client.Services.AppointmentService;

public interface IAppointmentService
{
    event Action OnChange;

    IList<Appointment> Appointments { get; set; }
    public Task GetAppointment();
    public Task<Appointment> AddOrUpdateAppointment(Appointment appointment);
}
