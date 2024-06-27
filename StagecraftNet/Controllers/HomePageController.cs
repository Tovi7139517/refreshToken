using Microsoft.AspNetCore.Mvc;
using Common;
using StagecraftDAL.Services;
using StagecraftApi.JwtManager;
using Microsoft.AspNetCore.Authorization;
using Common;
using Microsoft.Crm.Sdk.Messages;
//using System.Web.Mvc;
//using Microsoft.AspNetCore.Mvc;
namespace StagecraftNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomePageController : ControllerBase
    {

      
        private readonly ILogger<HomePageController> _logger;
        private static Dictionary<string, string> refreshTokenStore = new Dictionary<string, string>();
        public HomePageController(ILogger<HomePageController> logger)
        {
            _logger = logger;
            var t = 0;
        }

        [HttpGet]
        [Route("GetAllCourses")]
        [Authorize] // הוספת ה-attribute לאימות טוקן
        public ActionResult GetAllCourses()
        {
            // קריאה לפונקציה GetAllCourses שב-CourseService
            try
            {
                var t = CourseService.GetAllCourses();
                return Ok(t);
            }
            // לשלוף נתונים ולשלוף את רשימת הקורסים לתצוגה

            catch (Exception ex)
            {
                // הוסף לוגיקה ללוגים כאן
                return Ok(ex);
            }
        }
        [HttpGet()]
        [Authorize] // הוספת ה-attribute לאימות טוקן
        [Route("CheckIfEmailExist/{email}")]
        public ActionResult CheckIfEmailExist(string email)
        {
            try
            {
                var t = UsersService.CheckIfEmailExist(email);
                return Ok(t);
            }

            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet()]
        [Route("GetCoursById/{id}")]
        [Authorize] // הוספת ה-attribute לאימות טוקן
        public ActionResult GetCoursById(int id)
        {
            try
            {
                var t = CourseService.GetCoursById(id);
                return Ok(t);

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        
        [HttpGet("{id}")]
        //[Route("GetCourseDetails")]
        [Authorize] // הוספת ה-attribute לאימות טוקן
        public IActionResult GetCourseDetails()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Authorize]
        [Route("GetAvailableCourse")]
        public string GetAvailableCourse()
        {
            return "Course list placeholder";
        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp([FromBody] UsersDetails userDetails)
        {
            var token = JwtMiddleware.GenerateJwtToken("1234", "Rivka");
            var refreshToken = JwtMiddleware.GenerateRefreshToken();

            // Store the refresh token securely (for demonstration purposes, using an in-memory dictionary)
            refreshTokenStore["1234"] = refreshToken;

            return Ok(new { Token = token, RefreshToken = refreshToken });
        }
        [HttpPost("{id}")]
        public IActionResult SignUpForACourse([FromQuery] int courseId)
        {
            var token = JwtMiddleware.GenerateJwtToken("1234", "Rivka");
            var refreshToken = JwtMiddleware.GenerateRefreshToken();

            // Store the refresh token securely (for demonstration purposes, using an in-memory dictionary)
            refreshTokenStore["1234"] = refreshToken;

            return Ok(new { Token = token, RefreshToken = refreshToken });
        }
        [HttpPost]
        [Route("RefreshToken")]
        public IActionResult RefreshToken([FromBody] TokenRequest request)
        {
            // Validate the refresh token
            if (refreshTokenStore.TryGetValue("1234", out var storedRefreshToken) && JwtMiddleware.ValidateRefreshToken(request.RefreshToken, storedRefreshToken))
            {
                var newToken = JwtMiddleware.GenerateJwtToken("1234", "Rivka");
                string newRefreshToken = JwtMiddleware.GenerateRefreshToken();

                // Update the stored refresh token
                refreshTokenStore["1234"] = newRefreshToken;

                return Ok(new { Token = newToken, RefreshToken = newRefreshToken });
            }

            return Unauthorized();
        }



    }
}
