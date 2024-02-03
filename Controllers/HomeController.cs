using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MappingSolutionFinal.Models;
using Microsoft.AspNetCore.Authorization;

namespace MappingSolutionFinal.Controllers

{
    [Authorize]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly iJwTmanager Athenticatemanager;
        //single object of Class athenticate Will be used with all objects of Controller.not a big issue at all .
        public HomeController(iJwTmanager Athenticatemanager)
        {
            this.Athenticatemanager = Athenticatemanager;
        }

    }
}
    //    [AllowAnonymous]
    //    [HttpPost("athenticate")]
  //      [Route("athenticate")]
        
  //  public IActionResult Logout()
 //       {
         //   var token=Athenticatemanager.Athenticate(user.Username, user.Password);
          //  if (token == null)
          //      return Unauthorized();
          //  else {
          //      return Ok(token);
          //  }
            
    //    }
   // }
//}
