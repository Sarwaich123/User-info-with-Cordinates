using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using MappingSolutionFinal.Controllers;
using MappingSolutionFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace MappingSolutionFinal
{
    public class AuthenticateClass:iJwTmanager
    {

        private readonly string key;
        public AuthenticateClass(string key)
        {
            this.key = key;
        }
        
        public string Athenticate(string username, string role)
        {   
            var tokenholder = new JwtSecurityTokenHandler();
            var Tokenkey = Encoding.ASCII.GetBytes(key);
            var tokendiscriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                 new Claim[] { new Claim(ClaimTypes.Name, username),
                  new Claim(ClaimTypes.Role, role)
                 }
                     ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Tokenkey),
                    SecurityAlgorithms.HmacSha256)

            };
            var token = tokenholder.CreateToken(tokendiscriptor);
            return tokenholder.WriteToken(token);

        }
    }

}

