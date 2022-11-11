﻿using BlazorApp.Shared.User;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
}
