using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Apply> Applies { get; set; }

}
