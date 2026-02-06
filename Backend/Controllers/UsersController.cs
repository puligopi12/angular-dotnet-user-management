using EntityFrameWorkCoreFirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCoreFirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext userContext;

        public UsersController(UserContext userContext)
        {
            this.userContext = userContext;
        }

        // GET ALL USERS
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = userContext.Users.ToList();
            return Ok(users);
        }

        // GET USER BY ID
        [HttpGet("GetUser")]
        public IActionResult GetUser(int id)
        {
            var user = userContext.Users.Find(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // ADD USER
        [HttpPost("AddUser")]
        public IActionResult AddUser(Users user)
        {
            userContext.Users.Add(user);
            userContext.SaveChanges();
            return Ok(user);
        }

        // UPDATE USER
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(Users user)
        {
            var existingUser = userContext.Users.Find(user.ID);
            if (existingUser == null)
                return NotFound();

            existingUser.Name = user.Name;
            existingUser.Contact = user.Contact;

            userContext.SaveChanges();
            return Ok(existingUser);
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = userContext.Users.Find(id);
            if (user == null)
                return NotFound("User not found");

            userContext.Users.Remove(user);
            userContext.SaveChanges();
            return Ok();
        }

    }
}
