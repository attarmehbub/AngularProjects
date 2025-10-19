using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AngualrDemo.Services
{
   public class User
    {
        public string Id { get; set; }
    }
    public class Tokens
    {
        public static string SUPER_SECRET_KEY = "=32453dfgjfkd09340sdfsfdsfdsfdsssssssssssssssssssssssssssss345643gfgcvbtrhrrrrrrrrxcvx";
        //C#
        public static string GenerateToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SUPER_SECRET_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.Now.AddSeconds(30),//DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public static int? ValidateToken(string rawAuthHeader)
        {
            if (rawAuthHeader == null)
                return null;
            //get only the value [eyJ0eXAiOiJKV1...] from: Bearer eyJ0eXAiOiJKV1...
            String token = rawAuthHeader.Split(" ")[0];
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SUPER_SECRET_KEY);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // I'm not the author of this code :v
                // https://jasonwatmore.com/post/2021/06/02/net-5-create-and-validate-jwt-tokens-use-custom-jwt-middleware
                return null;
            }
        }
    }

    public class TokensTest
    {
       public TokensTest() { }
        public async Task Invoke(HttpContext httpContext)
        {
            var test = "123!";

        }
        public static void genarate(string userName, string password)
        {
            byte[] signingKey = new byte[32];
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.NameIdentifier, userName),
                new Claim(ClaimTypes.Name, password)
            }),
               // Expires = DateTime.UtcNow.AddYears(100),
                Expires = DateTime.Now.AddSeconds(30),
                Issuer = "vcsjones",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(signingKey),
                    SecurityAlgorithms.HmacSha256),
            };

            JsonWebTokenHandler handler = new();
            string token = handler.CreateToken(tokenDescriptor);

            Console.WriteLine(token);

            TokenValidationResult result = handler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuers = new string[] { "vcsjones" },
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                     ClockSkew = TimeSpan.Zero
                }
            );

            //Console.WriteLine(result.IsValid);
        }
    }
}
