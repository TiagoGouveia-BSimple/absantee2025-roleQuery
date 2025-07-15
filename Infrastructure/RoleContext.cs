using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class RoleContext : DbContext
{
    public virtual DbSet<RoleDataModel> Roles { get; set; }

    public RoleContext(DbContextOptions<RoleContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoleDataModel>()
            .HasKey(v => v.Id);

        base.OnModelCreating(modelBuilder);
    }
}
