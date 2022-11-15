namespace BlazorApp.Shared;

public class Portfolio
{
    public int Id { get; set; }

    // user model
    public User? User { get; set; }
    public int UserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string SideName { get; set; } = string.Empty;
    public string RightName { get; set; } = string.Empty;
    public string RightEnglishName { get; set; } = string.Empty;
    public DateTime CameraTestDateUpdated { get; set; } = DateTime.Now;
    public DateTime HighlightDateUpdated { get; set; } = DateTime.Now;
    public string AboutIntroduce { get; set; } = string.Empty;
    public string AboutBirthday{ get; set; } = string.Empty;
    public string AboutPhone { get; set; } = string.Empty;
    public int AboutAge { get; set; }
    public string AboutEmail { get; set; } = string.Empty;
    public string AboutSize { get; set; } = string.Empty;
    public string AboutMainFilmograpy1 { get; set; } = string.Empty;
    public string AboutMainFilmograpy2 { get; set; } = string.Empty;
    public string AboutMainFilmograpy3 { get; set; } = string.Empty;
    public string AboutMainFilmograpy4 { get; set; } = string.Empty;
    public string Concept1 { get; set; } = string.Empty;
    public string Concept2 { get; set; } = string.Empty;


    public DateTime DateUpdated { get; set; } = DateTime.Now;
}