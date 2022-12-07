using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services.AppointmentService;

public class AppointmentService : IAppointmentService
{
    private readonly HttpClient _http;

    public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
    public AppointmentService(HttpClient http)
    {
        _http = http;
    }
    
    public event Action OnChange;

    public async Task GetAppointment()
    {
        var response = await _http.GetFromJsonAsync<ServiceResponse<IList<Appointment>>>("api/appointment");

        Appointments = response.Data;
    }

    public async Task<Appointment> AddOrUpdateAppointment(Appointment appointment)
    {
        var response = await _http.PostAsJsonAsync("api/appointment", appointment);

        return response.Content.ReadFromJsonAsync<ServiceResponse<Appointment>>().Result.Data;
    }

    
}
