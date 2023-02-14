using Microsoft.EntityFrameworkCore;
using ToObjective.Models;

namespace ToObjective.Data;

public class ObjectiveDbContext :DbContext
{
	public ObjectiveDbContext(DbContextOptions<ObjectiveDbContext> options) : base(options)
	{
	}

    public DbSet<Objective> Objectives { get; set;}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Objective>().Property(o => o.Id)
			.HasColumnName("ID")
			.IsRequired();
		modelBuilder.Entity<Objective>().Property(o => o.Title)
			.HasColumnName("Title")
			.IsRequired();
		modelBuilder.Entity<Objective>().Property(o => o.Description)
			.HasColumnName("Description")
			.HasDefaultValue("No Description");
        modelBuilder.Entity<Objective>().Property(o => o.CompleteByDate)
            .HasColumnName("CompleteByDate")
            .HasDefaultValue(DateTime.Now)
            .IsRequired();
        modelBuilder.Entity<Objective>().Property(o => o.CreatedDate)
            .HasColumnName("CreatedDate")
            .HasDefaultValue(DateTime.Now)
            .IsRequired();
        modelBuilder.Entity<Objective>().Property(o => o.UpdatedDate)
            .HasColumnName("UpdatedDate")
            .HasDefaultValue(DateTime.Now)
            .IsRequired();
        modelBuilder.Entity<Objective>().Property(o => o.CompletedDate)
            .HasColumnName("CompletedDate")
            .HasDefaultValue(DateTime.Now);
    }

}


