using LamilaDinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace LamilaDinner.Infrastructure.Persistence;

public class LamilaDinnerDbContext : DbContext
{
    public LamilaDinnerDbContext(DbContextOptions<LamilaDinnerDbContext> options) : base(options)
    {

    }

    public DbSet<Menu> Menus {get;set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LamilaDinnerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}