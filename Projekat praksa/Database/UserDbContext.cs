using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Projekat_praksa.Database
{
	public class UserDbContext : IdentityDbContext<User>
	{
		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

		public DbSet<User> Users {  get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.HasDefaultSchema("identity"); 
		}
	}

	
}
