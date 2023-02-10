using Microsoft.EntityFrameworkCore;
using ToObjective.Models;

namespace ToObjective.Data;

public class ObjectiveDbContext :DbContext
{
	public ObjectiveDbContext(DbContextOptions<ObjectiveDbContext> options) : base(options)
	{
	}

    public DbSet<Objective> Objectives { get; set;}

}


