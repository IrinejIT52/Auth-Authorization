using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Projekat_praksa.Database
{
	public class UserRepository
	{
		private readonly UserDbContext _dbContext;

		public UserRepository(UserDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void AddRole(IdentityRole role)
		{
			_dbContext.Roles.Add(role);
			_dbContext.SaveChanges();
		}

		public void AddUserRole(IdentityUserRole<string> userRole) 
		{
			_dbContext.UserRoles.Add(userRole);
			_dbContext.SaveChanges();
		}
	}
}
