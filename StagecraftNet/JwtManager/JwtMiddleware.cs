using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using static System.Net.Mime.MediaTypeNames;

namespace StagecraftApi.JwtManager
{
    public class JwtMiddleware
    {
        private static string secretKey = "Stagecraft secret for generate Jwt Token"; // מפתח סודי לחתימת הטוקן
                                                                                      //משתנה לריענון טוקן
                                                                                      //public required string RefreshToken {  get; set; }
        private readonly RequestDelegate _next;

        //var refreshToken=GenerateRefreshToken();
        public JwtMiddleware(RequestDelegate next)
        {

            _next = next;

        }
        // יצירת טוקן JWT
        public static string GenerateJwtToken(string userId, string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, userName),
            // ניתן להוסיף קליימים נוספים כפי שרלוונטי ליישום שלך
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1), // זמן תוקף של הטוקן
                SigningCredentials = credentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // אימות טוקן JWT
        public ClaimsPrincipal ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(secretKey);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false, // לפי הצורך שלך, ניתן לשנות
                ValidateAudience = false, // לפי הצורך שלך, ניתן לשנות
                ClockSkew = TimeSpan.Zero // אין דלאי בזמן ביצוע הטוקן
            };

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            return principal;
        }

        //ניסוי

        //public async System.Threading.Tasks.Task Invoke(HttpContext context)
        //{
        //    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //    if (token != null)
        //        await Console.Out.WriteLineAsync("ללללללללללללל");

        //}

        //נכנס לפה כל פעם לאמת את הטוקן
        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                // Example: Output token to console
                await Console.Out.WriteLineAsync($"Token received: {token}");
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
        //private bool IsAccessTokenExpierd(string accessToken)
        //{
        //    return true;
        //}
        // Generate Refresh Token
        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

       // Validate Refresh Token
        public static bool ValidateRefreshToken(string token, string storedToken)
        {
            return token == storedToken;
        }

    }
}
