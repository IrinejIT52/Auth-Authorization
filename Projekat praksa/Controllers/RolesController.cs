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
		private readonly UserRepository _userRepository;

		public RolesController(UserRepository userRepository)
		{
			_userRepository = userRepository;	
		}

		[HttpPost("addRoles")]
		public ActionResult AddRole(IdentityRole role)
		{
			_userRepository.AddRole(role);

			return Ok();
		}

		[HttpPost("user/{userid}/role/{roleid}")]
		public ActionResult AddUserRole(string userid, string roleid)
		{
			_userRepository.AddUserRole(new IdentityUserRole<string> { RoleId=roleid, UserId=userid});

			return Ok();
		}

		[HttpPost("user/{userid}/admin")]
		public ActionResult AddUserRoleAdmin(string userid)
		{
			_userRepository.AddUserRole(new IdentityUserRole<string> { RoleId = Constants.Constants.adminId , UserId = userid });

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
