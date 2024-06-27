using Microsoft.AspNetCore.Mvc;
using Common;


namespace StagecraftNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class loginController : ControllerBase
    {

        private readonly ILogger<HomePageController> _logger;
        private readonly List<loginController> users = new List<loginController>();

        public loginController(ILogger<HomePageController> logger )
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SignUp([FromBody] Users userDetails)
        {
            throw new NotImplementedException();
        }
        //[HttpPost("login")]

        //public IActionResult Login([FromBody] UserLoginRequest request)
        //{
        //    var user = users.FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);
        //    if (user != null)
        //    {
        //        return Ok(new { message = "משתמש נמצא במערכת" });
        //    }
        //    else
        //    {
        //        return NotFound(new { message = "משתמש לא נמצא במערכת" });
        //    }
        //    throw new NotImplementedException();
        //}



    }
}
