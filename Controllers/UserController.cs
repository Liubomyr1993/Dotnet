using System;
using System.Collections.Generic;
using System.Linq;
using Dotnet.models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dotnet.Controllers
{
    

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
       private List<Users> newusers = new List<Users>{
           new Users {Id = 0, FirstName = "Roman", LastName = "Smith", BirthDay = "1990-01-01"},
           new Users {Id = 1, FirstName = "Ivan", LastName = "Great", BirthDay = "1985-02-12"}

       };
       [HttpGet]
       public IEnumerable<Users> Get()
       {
           return newusers;
       }
       [HttpGet("{id}")]
       public ActionResult<Users> Get(int id)
       {
           Users newuser = newusers.FirstOrDefault(c => c.Id == id);
           if (newuser == null)
           {
               return NotFound(new {Message = "User has not been found."});
           }
           return Ok(newuser);
       }
       [HttpPost]
       public ActionResult<IEnumerable<Users>> Post(Users newUser)
       {
           newusers.Add(newUser);
           return newusers;
       }
       [HttpPut]

       public ActionResult<IEnumerable<Users>> Put(int id, Users updateUser)
       {
           Users newuser = newusers.FirstOrDefault(c => c.Id == id);
           if (newuser == null)
           {
               return NotFound();
           }

            newuser.FirstName = updateUser.FirstName;
            newuser.LastName = updateUser.LastName;
            newuser.BirthDay = updateUser.BirthDay;

            return newusers;
           
       }
       
        [HttpDelete("{id}")]

        public ActionResult<IEnumerable<Users>> Delete(int id)
        {  
            Users newuser = newusers.FirstOrDefault(c => c.Id == id);
           if (newuser == null)
           {
               return NotFound();
           }
           newusers.Remove(newuser);

           return newusers;
        }

    }
}