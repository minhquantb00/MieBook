using BookManagement.Application.IUseCases;
using BookManagement.Application.ResponseModels;
using BookManagement.Commons.UtilitiesGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.Login
{
    public class LoginUserUseCase : IUseCase<LoginUserUseCaseInput, LoginUserUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<RefreshToken> _refreshTokenRepository;
        public LoginUserUseCase(
            IRepository<User> userRepository, 
            IConfiguration configuration, 
            IRepository<UserRole> userRoleRepository, 
            IRepository<Role> roleRepository, 
            IRepository<RefreshToken> refreshTokenRepository
            )
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<LoginUserUseCaseOutput> ExcuteAsync(LoginUserUseCaseInput input)
        {
            var resultOuput = new LoginUserUseCaseOutput
            {
                Succeeded = false
            };
            var user = await _userRepository.GetUserByEmail(input.Email);
            if (user == null)
            {
                resultOuput.Errors = new string[] { "Email không tồn tại trên hệ thống" };
                return resultOuput;
            }
            var checkPassword = Utilities.IsPasswordValid(input.Password, user.Password);
            if (!checkPassword)
            {
                resultOuput.Errors = new string[] { "Mật khẩu không chính xác" };
                return resultOuput;
            }
            try
            {
                string accessToken = GetJwtTokenAsync(user).Result.AccessToken;
                string refreshToken = GetJwtTokenAsync(user).Result.RefreshToken;
                resultOuput.Succeeded = true;
                resultOuput.AccessToken = accessToken;
                resultOuput.RefreshToken = refreshToken;
                return resultOuput;
            }
            catch (Exception ex)
            {
                resultOuput.Succeeded = false;
                resultOuput.Errors = new string[] { ex.Message };
                return resultOuput;
            }
        }


        #region Handle Token
        private async Task<DataResponseLogin> GetJwtTokenAsync(User user)
        {
            var permissions = await _userRoleRepository.GetAllAsync(x => x.UserId == user.Id);
            var roles = await _roleRepository.GetAllAsync();

            var authClaims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("FullName", user.FullName),
                new Claim("ExpiredTime", DateTime.Now.AddHours(3).ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                
            };
            var listRoleId = permissions.Select(x => x.RoleId).ToHashSet();
            var listId = roles.Select(x => x.Id).ToHashSet();
            foreach (var role in roles)
            {
                if (listRoleId.Contains(role.Id))
                {
                    authClaims.Add(new Claim("Permission", role.Name));
                }
            }

            var userRoles = await _userRepository.GetRolesOfUserAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtToken = GetToken(authClaims);
            var refreshToken = GenerateRefreshToken();
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidity"], out int refreshTokenValidity);

            RefreshToken rf = new RefreshToken
            {
                UserId = user.Id,
                ExpiredTime = DateTime.UtcNow.AddHours(refreshTokenValidity),
                Token = refreshToken,
                CreateTime = DateTime.Now
            };

            rf = await _refreshTokenRepository.CreateAsync(rf);

            return new DataResponseLogin
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                RefreshToken = refreshToken,
            };
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInHours"], out int tokenValidityInMinutes);
            var expirationTimeUtc = DateTime.UtcNow.AddHours(tokenValidityInMinutes);
            var localTimeZone = TimeZoneInfo.Local;
            var expirationTimeInLocalTimeZone = TimeZoneInfo.ConvertTimeFromUtc(expirationTimeUtc, localTimeZone);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: expirationTimeInLocalTimeZone,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new Byte[64];
            var range = RandomNumberGenerator.Create();
            range.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        #endregion
    }
}
