namespace BlazorApp.Shared;

public class Portfolio
{
    public int Id { get; set; }

    // user model
    public User? User { get; set; }
    public int UserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string SideName { get; set; } = string.Empty;
    public string Concept1 { get; set; } = string.Empty;
    public string Concept2 { get; set; } = string.Empty;
    public DateTime DateUpdated { get; set; } = DateTime.Now;
}