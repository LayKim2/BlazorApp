namespace BlazorApp.Server.Services.AppointmentService;

public interface IAppointmentService
{
    public Task<ServiceResponse<IList<Appointment>>> GetAppointment();
    Task<ServiceResponse<Appointment>> AddorUpdateAppointment(Appointment appointment);
}
