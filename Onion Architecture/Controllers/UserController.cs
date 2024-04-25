using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Contract;

namespace Onion_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            this._user = user;
        }
        //get all users
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var response =_user.GetAllRepo();
            return Ok(response);
        }
        //get by id
        [HttpGet("get")]
        public IActionResult GetById(long id) 
        {
            return Ok(_user.GetByIdRepo(id));
        }

        //add user
        [HttpPost("add")]
        public IActionResult AddUser(User user)
        {
            return Ok(_user.AddUserRepo(user));
        }

        //remove user
        [HttpDelete]
        public IActionResult DeleteUser(long id)
        {
            return Ok(_user.DeleteUser(id));
        }

        //update user
        [HttpPut("edit")]
        public IActionResult EditUser(User user)
        {
            return Ok(_user.UpdateUserRepo(user));
        }
    }
}
