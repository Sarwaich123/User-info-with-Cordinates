using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MappingSolutionFinal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace MappingSolutionFinal.Controllers
{
    [Route("ViewRecord")]
    public class GetusersController : Controller
    {
        private readonly DB_APICONTEXT _context;

        public GetusersController(DB_APICONTEXT context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Getuser")]
        public async Task<ActionResult<IEnumerable<Getuser>>> Getusers()
        {
            
            string procedureName = "exec VIEWRECORD";
            var result = await _context.Getuser.FromSqlRaw(procedureName).ToListAsync();
            return result;



        }


        [HttpPost]
        [Route("deleteuser")]
        public string DeleteUser([FromBody]Deletioninput record)
        {
            SqlParameter sqlParameter = new SqlParameter("@ID", record.id);
            string procedureName = "exec DELETERECORD @ID";
            int result = _context.Database.ExecuteSqlRaw(procedureName, sqlParameter);
            if(result==0)
            {
                return "No record found to Delete";
            }
            else
            {
                return "Deletion performed Successfully";
            }


 

        }

        [AllowAnonymous]
        [HttpPost()]
        [Route("adduser")]
        public string adduser([FromBody] addusermodel record)
        {
              SqlParameter sqlParameter1 = new SqlParameter("@username", record.Username);
              SqlParameter sqlParameter2 = new SqlParameter("@password", record.Password);
              SqlParameter sqlParameter3 = new SqlParameter("@CityStation", record.Station_City);
              SqlParameter sqlParameter4 = new SqlParameter("@Role", record.Role);
              SqlParameter sqlParameter5 = new SqlParameter("@Latitude", record.Latitude);
              SqlParameter sqlParameter6 = new SqlParameter("@Longitude", record.Longitude);

              string procedureName = "exec INSERTRECORD @username,@password,@CityStation,@Role,@Latitude,@Longitude";
              int result = _context.Database.ExecuteSqlRaw(procedureName, sqlParameter1, sqlParameter2, sqlParameter3, sqlParameter4, sqlParameter5, sqlParameter6);
              if (result == 0)
              {
                  return "Insertion Failed";
              }
              else
              {
                  return "Insertion performed Successfully";
              }


             
        }
    }
}
