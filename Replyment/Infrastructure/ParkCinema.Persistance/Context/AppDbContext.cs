using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Replyment.Domain.Entities.Domain> Domains { get; set; }
    public DbSet<WidgetAllStyle> WidgetAllStyles { get; set; }
    public DbSet<CustomButton> CustomButtons { get; set; }
    public DbSet<Agents> Agents { get; set; }
    public DbSet<TriggerStatus> TriggerStatuses { get; set; }
}
