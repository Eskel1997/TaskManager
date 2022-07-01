using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TASKMANAGER.DB.Exceptions;
using TASKMANAGER.DB.Extensions;
using TASKMANAGER.INFRASTRUCTURE.Managers.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Models;
using TASKMANAGER.INFRASTRUCTURE.Settings;

namespace TASKMANAGER.INFRASTRUCTURE.Managers.Concrete
{
    internal class TokenManager : ITokenManager
    {
        private readonly JwtSettings _jwtSettings;
        public TokenManager(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public TokenModel GenerateToken(long userId, string userPublicId, string email, string name, string surname, string pictureUrl)
        {
            var secretKey = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256);
            var expires = now.AddMinutes(_jwtSettings.ExpiryTime);

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            var refreshToken = GenerateRefreshToken();

            var tokenModel = new TokenModel()
            {
                Token = token,
                RefreshToken =  refreshToken,
                ExpirationTime = expires,
                UserId = userPublicId,
                Email = email,
                Name = name,
                Surname = surname,
                PictureUrl = pictureUrl
            };

            return tokenModel;
        }

        public long GetIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            try
            {
                var principal = tokenHandler.ValidateToken(
                    token,
                    new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = false,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
                    },
                    out var validatedToken);

                var userId = principal.GetUserId();

                return userId;
            }
            catch
            {
                throw new TaskManagerException(ErrorCode.IncorrectAuthCredentials);
            }
        }

        public void CompareRefreshTokens(string givenToken, string refreshToken)
        {
            if (givenToken != refreshToken)
            {
                throw new TaskManagerException(ErrorCode.IncorrectAuthCredentials);
            }
        }

        private static string GenerateRefreshToken()
        {
            var number = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
