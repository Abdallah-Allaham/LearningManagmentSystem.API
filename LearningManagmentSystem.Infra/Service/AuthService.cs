using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.DTO;
using LearningManagmentSystem.Core.Repo;
using LearningManagmentSystem.Core.Service;
using Microsoft.IdentityModel.Tokens;

namespace LearningManagmentSystem.Infra.Service
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepo _authRepo;
        public AuthService(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        // here we will work on logic
        public string Login(Login login)
        {
            var result= _authRepo.Login(login);

            if (result == null) return null;

            return GenerateJWTToken(result);
        }

        public string GenerateJWTToken(LoginDTO user)
        {
            //1. Create Secret Key
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                ("symmetricsecuritykey12345"));

            var siginingCredentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256);

            //2. Payload - Data //related to information about user like username or password
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Roleid.ToString())
            };

            //3. create JWT Token with options
            var tokenOpetions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials:siginingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOpetions);//to return token as string

        }

        
    }
}
