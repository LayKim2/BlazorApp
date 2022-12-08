
namespace BlazorApp.Shared;

public class Apply
{
    public int Id { get; set; }
    public User? User { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}
