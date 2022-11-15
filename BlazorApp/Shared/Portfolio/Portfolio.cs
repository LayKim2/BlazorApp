using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Shared.Portfolio;

public class Portfolio
{
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserID { get; set; }
    public string SideName { get; set; } = string.Empty;
    public string Concept1 { get; set; } = string.Empty;
    public string Concept2 { get; set; } = string.Empty;
    public DateTime DateUpdated { get; set; } = DateTime.Now;
}