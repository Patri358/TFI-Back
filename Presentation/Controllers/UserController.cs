using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Application.Interfaces;
using System.Runtime.InteropServices.Marshalling;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> Get()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
