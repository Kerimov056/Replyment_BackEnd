﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Replyment.Domain.Entities;
using Replyment.Persistance.Configurations;

namespace Replyment.Persistance.Context;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SliderConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Slider> Sliders { get; set; }
    public DbSet<CustomizeButton> CustomizeButtons { get; set; }
}
