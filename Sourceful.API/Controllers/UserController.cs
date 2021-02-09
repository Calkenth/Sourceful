using Microsoft.AspNetCore.Mvc;
using Sourceful.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sourceful.Core.Services;
using Sourceful.Data.ViewModels;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sourceful.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userServices;
        private readonly IMapper mapper;

        public UserController(IUserServices userService, IMapper mapper)
        {
            this.userServices = userService;
            this.mapper = mapper;
        }

        // GET: api/<UserController>/GetUsers
        [HttpGet("GetUsers")]
        public async Task<IEnumerable<User>> Get()
        {
            return await userServices.GetAllUsersAsync();
        }

        // GET api/<UserController>/GetUser/5
        [HttpGet("GetUser/{id}")]
        public async Task<UserDetailViewModel> Get(int id)
        {
            var user = await userServices.GetUserAsync(id);

            if (user == null)
            {
                return null;
            }
            var mapped = mapper.Map<UserDetailViewModel>(user);

            return mapper.Map<UserDetailViewModel>(user);
        }

        // POST api/<UserController>/CreateUser
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] object jsonString)
        {
            var user = JsonConvert.DeserializeObject<UserDetailViewModel>(jsonString.ToString());
            if (user != null)
            {
                try
                {
                    var mappedUser = mapper.Map<User>(user);
                    mappedUser.Address = mapper.Map<Address>(user);
                    mappedUser.Info = mapper.Map<Info>(user);

                    var response = await userServices.CreateUserAsync(mappedUser);

                    if (response <= 0)
                    {
                        throw new Exception("User not created");
                    }
                    return Ok(response);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE api/<UserController>/DeleteUser/5
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id > 0)
            {
                var user = await userServices.GetUserAsync(id);
                if(user == null)
                {
                    return NotFound();
                }

                var response = await userServices.DeleteUserAsync(user);
                if(response <= 0)
                {
                    throw new Exception("No user was deleted");
                }
                return Ok();
            }
            return NotFound();
        }
    }
}
