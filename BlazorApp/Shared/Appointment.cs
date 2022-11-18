

namespace BlazorApp.Shared;

public class Appointment
{
    public int Id { get; set; }
    public DateTime? Start { get; set; } = global::System.DateTime.Now;
    public DateTime? End { get; set; } = global::System.DateTime.Now;
    public string Text { get; set; }
}
