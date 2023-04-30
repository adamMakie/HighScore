using Highscore.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace Highscore.Data;

public class ApplicationContext : IdentityDbContext<IdentityUser>
{
	public ApplicationContext(DbContextOptions<ApplicationContext> options)
		: base(options)
	{

	}
	public DbSet<Score> Scores { get; set; }

	public DbSet<Game> Game { get; set; }

	public DbSet<IdentityUser> IdentityUsers { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Score>()
			 .HasOne<Game>(s => s.Game)
			 .WithMany(g => g.Scores)
			 .HasForeignKey(s => s.GameId);

		base.OnModelCreating(modelBuilder);
      
		var administrator = new IdentityRole("Administrator");

      modelBuilder
          .Entity<IdentityRole>()
          .HasData(administrator);
         


   }

}



