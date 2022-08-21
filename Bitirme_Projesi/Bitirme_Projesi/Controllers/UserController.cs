using Bitirme_Projesi_Data.Models;
using Bitirme_Projesi_Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bitirme_Projesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices _usersevice=null;
        public UserController(IUserServices usersevice)
        {
            _usersevice = usersevice;

        }
        
        // GET api/<UserController>/5
        

        // POST api/<UserController>
        [HttpPost("SignUp")]
        public User SignUp([FromBody] User oUser)
        {
            return _usersevice.Signup(oUser);
        }


        [HttpPost("Login")]
        public User Login([FromBody] User oUser)
        {
            return _usersevice.Login(oUser);
        }


    }
}
