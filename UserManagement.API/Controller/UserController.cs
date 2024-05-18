using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using UserManagement.API.DTO;

namespace UserManagement.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Now apply DI for User service and profile service [user+profile : unit of work + repository pattern]
        private readonly IUserService userService;
        IMapper userDTOMapper;
        private readonly IProfileService userProfileService;
        public UserController(IUserService userService, IProfileService _profileservice, IMapper mapper)
        {
            this.userService = userService;
            this.userProfileService = _profileservice;
            this.userDTOMapper=mapper;

        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateAccount(UserProfileDTO model)
        {
            // User userEntity = new User
            // {
            //     //Fatty Controller starts here..
            //     UserName = model.UserName,
            //     Email = model.Email,
            //     Password = model.Password,
            //     AddedDate = DateTime.UtcNow,
            //     ModifiedDate = DateTime.UtcNow,
            //     IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            //     UserProfile = new UserProfile
            //     {
            //         FirstName = model.FirstName,
            //         LastName = model.LastName,
            //         Address = model.Address,
            //         AddedDate = DateTime.UtcNow,
            //         ModifiedDate = DateTime.UtcNow,
            //         IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
            //     }
            // };
            var userEntity = userDTOMapper.Map<User>(model);
            userEntity.UserProfile = userDTOMapper.Map<UserProfile>(model);
            userService.InsertUser(userEntity);
            return Ok("User Created");
         
        }

        // [HttpPut("UpdateUser/{id}")]
        // public IActionResult UpdateAccount(UserProfileDTO model)
        // {
        //     if(model.Id<1)
        //     {
        //         return BadRequest();
        //     }
        //     User userEntity = userService.GetUser(model.Id);
        //     userEntity.Email = model.Email;
        //     userEntity.ModifiedDate = DateTime.UtcNow;
        //     userEntity.Password=model.Password;
        //     userEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
        //     UserProfile userProfileEntity = userProfileService.GetUserProfile(model.Id);
        //     userProfileEntity.FirstName = model.FirstName;
        //     userProfileEntity.LastName = model.LastName;
        //     userProfileEntity.Address = model.Address;
        //     userProfileEntity.ModifiedDate = DateTime.UtcNow;
        //     userProfileEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
        //     userEntity.UserProfile = userProfileEntity;
        //     userService.UpdateUser(userEntity);
        //     return Ok(model);
        // }

        [HttpDelete("DeleteUser/{id}")]
        public void DeleteAccount(int id)
        {
            UserProfile userProfile = userProfileService.GetUserProfile(id);
            userService.DeleteUser(id);
        }
        
        [HttpGet("Users")]
        public IActionResult GetUser()
        {
            return Ok(userService.GetUsers());
        }

    }
}
