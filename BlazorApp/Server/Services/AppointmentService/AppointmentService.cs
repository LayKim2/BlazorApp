using System.Security.Claims;

namespace BlazorApp.Server.Services.AppointmentService;

public class AppointmentService : IAppointmentService
{
    private readonly DataContext _context;
    private readonly IAuthService _authService;

    public AppointmentService(DataContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public async Task<ServiceResponse<IList<Appointment>>> GetAppointment()
    {
        int userId = _authService.GetUserId();

        var appointments = await _context.Appointments.Where(a => a.UserId == userId).ToListAsync();

        return new ServiceResponse<IList<Appointment>> { Data = appointments };
    }

    public async Task<ServiceResponse<Appointment>> AddorUpdateAppointment(Appointment appointment)
    {
        var response = new ServiceResponse<Appointment>();

        try
        {
            appointment.UserId = _authService.GetUserId();

            if (appointment.Id == 0)
            {
                // insert
                _context.Appointments.Add(appointment);

                response.Data = appointment;
            }
            else
            {
                // update
                var updateModel = await _context.Appointments.Where(a => a.UserId == appointment.UserId && a.Id == appointment.Id).FirstOrDefaultAsync();

                if (updateModel == null)
                {
                    return new ServiceResponse<Appointment>()
                    {
                        Success = false,
                        Message = "User not found."
                    };
                }

                updateModel.Start = appointment.Start;
                updateModel.End = appointment.End;
                updateModel.Text = appointment.Text;

                response.Data = appointment;
            }

            await _context.SaveChangesAsync();

            return response;
        }
        catch(Exception e)
        {
            return new ServiceResponse<Appointment>()
            {
                Success = false,
                Message = "Appointment save failed."
            };
        }
    }

    
}
