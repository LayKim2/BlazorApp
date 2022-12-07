using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IList<Appointment>>>> GetAppointment(int id)
        {
            return await _appointmentService.GetAppointment();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Appointment>>> AddorUpdateAppointment(Appointment appointment)
        {
            return await _appointmentService.AddorUpdateAppointment(appointment);
        }
    }
}
