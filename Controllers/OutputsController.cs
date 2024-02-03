using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MappingSolutionFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using System.Data;
using MappingSolutionFinal;

namespace MappingSolutionFinal.Controllers
{

    [AllowAnonymous]
    [Route("Login")]
    public class OutputsController : Controller
    {
        private  DB_APICONTEXT _context;
        private readonly iJwTmanager Athenticatemanager;

        public OutputsController(DB_APICONTEXT context, iJwTmanager Athenticatemanager)
        {
            _context = context;
            this.Athenticatemanager = Athenticatemanager;
        }
        [AllowAnonymous]
        [HttpPost()]
        [Route("Login")]
        public async Task<ActionResult<IEnumerable<Output>>> Getoutput([FromBody]Users user)
        {
            
            SqlParameter sqlParameter = new SqlParameter("@username", user.Username);
            SqlParameter sqlParameter1 = new SqlParameter("@password", user.Password);
            var role = new SqlParameter
            {
                ParameterName = "@role",
                DbType = DbType.String,
                Size = 50,
                Direction = ParameterDirection.Output
            };

            string procedureName = "exec testing @username,@password";
            var result=await _context.Output.FromSqlRaw(procedureName,sqlParameter,sqlParameter1).ToListAsync();
           // return result;
            string rolefinal = result[0].Role;
            if (rolefinal == null)
            {
                return Unauthorized();

            }
            else
            {
                var token = Athenticatemanager.Athenticate(user.Username, rolefinal);
                if (token == null)
                    return Unauthorized();
                else
                {
                    return Ok(token);

                }


            }


        }



    }
}
