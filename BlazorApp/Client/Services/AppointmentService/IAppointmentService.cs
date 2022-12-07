namespace BlazorApp.Client.Services.AppointmentService;

public interface IAppointmentService
{
    event Action OnChange;

    IList<Appointment> Appointments { get; set; }
    public Task<IList<Appointment>> GetAppointment();
    public Task<Appointment> AddOrUpdateAppointment(Appointment appointment);
}
