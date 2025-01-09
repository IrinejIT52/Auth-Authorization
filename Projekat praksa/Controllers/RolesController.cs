using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Projekat_praksa.Constants;
using Projekat_praksa.Database;


namespace Projekat_praksa.Controllers
{
	[Route("api/")]
	[ApiController]
	public class RolesController : ControllerBase
	{

			return Ok();
		}

		[HttpPost("user/{userid}/user")]
		public ActionResult AddUserRoleUser(string userid)
		{
			_userRepository.AddUserRole(new IdentityUserRole<string> { RoleId = Constants.Constants.userId, UserId = userid });

			return Ok();
		}

	}
}
