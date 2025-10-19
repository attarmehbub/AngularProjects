using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AngualrDemo.Services
{
    public class EncryptDecryptGCM
    {
        public static string Encrypt(string PlainText)
        {

            byte[] key = new byte[32];
            byte[] iv = new byte[16];
            string sR = string.Empty;

            try
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(PlainText);

                GcmBlockCipher cipher = new GcmBlockCipher(new AesFastEngine());
                AeadParameters parameters =
                             new AeadParameters(new KeyParameter(key), 128, iv, null);

                cipher.Init(true, parameters);

                byte[] encryptedBytes =
                       new byte[cipher.GetOutputSize(plainBytes.Length)];
                Int32 retLen = cipher.ProcessBytes
                               (plainBytes, 0, plainBytes.Length, encryptedBytes, 0);
                cipher.DoFinal(encryptedBytes, retLen);
                sR = Convert.ToBase64String
                     (encryptedBytes, Base64FormattingOptions.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return sR;
        }

        public static string Decrypt(string EncryptedText)
        {
            byte[] key = new byte[32];
            byte[] iv = new byte[16];
            string sR = string.Empty;
            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(EncryptedText);

                GcmBlockCipher cipher = new GcmBlockCipher(new AesFastEngine());
                AeadParameters parameters =
                          new AeadParameters(new KeyParameter(key), 128, iv, null);
                //ParametersWithIV parameters =
                //new ParametersWithIV(new KeyParameter(key), iv);

                cipher.Init(false, parameters);
                byte[] plainBytes =
                      new byte[cipher.GetOutputSize(encryptedBytes.Length)];
                Int32 retLen = cipher.ProcessBytes
                      (encryptedBytes, 0, encryptedBytes.Length, plainBytes, 0);
                cipher.DoFinal(plainBytes, retLen);

                sR = Encoding.UTF8.GetString(plainBytes).TrimEnd
                     ("\r\n\0".ToCharArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return sR;
        }

        public static void JWTTokenCreation()
        {
            var key = new RsaSecurityKey(RSA.Create(2048));
            var handler = new JsonWebTokenHandler();
            var now = DateTime.UtcNow;

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "me",
                Audience = "you",
                IssuedAt = now,
                NotBefore = now,
                Expires = now.AddMinutes(5),
                Subject = new ClaimsIdentity(new List<Claim> { new Claim("sub", "scott") }),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSsaPssSha256)
            };

            string jwt = handler.CreateToken(descriptor);
            ValidateJWTToken(jwt);
        }

        public static void ValidateJWTToken(string jwt)
        {
           // var key = new RsaSecurityKey(RSA.Create(2048));
            var handler = new JsonWebTokenHandler();
            TokenValidationResult result = handler.ValidateToken(jwt,
            new TokenValidationParameters
            {
                ValidIssuer = "me",
                ValidAudience = "you",
                IssuerSigningKey = new RsaSecurityKey(null)
                //IssuerSigningKey = new RsaSecurityKey(key.Rsa.ExportParameters(false))
            });
        }
    }
}
