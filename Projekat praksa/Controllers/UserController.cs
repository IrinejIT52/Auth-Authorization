using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projekat_praksa.Database;
using System.Security.Claims;

namespace Projekat_praksa.Controllers
{
	[Route("api/")]
	[ApiController]
	[Authorize]
	public class UserController : Controller
	{

		private readonly UserManager<Database.User> _userManager;

		public UserController(UserManager<Database.User> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet("profile")]
		public async Task<ActionResult<Database.User>> GetUserInfo()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
			if (userId == null)
			{
				return Unauthorized(); 
			}

			// Retrieve the user from the database
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return NotFound(); 
			}

			
			var userProfile = new
			{
				user.Id,
				user.Email
			};

			return Ok(userProfile);
		}


		[HttpGet("profile/{email}")]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<Database.User>> GetUserId(string email)
		{

			var user = await _userManager.FindByEmailAsync(email);

			if (user == null)
			{
				return NotFound("User not found.");
			}

			// Return the user ID
			return Ok(new { userId = user.Id });

		}
	}
}
