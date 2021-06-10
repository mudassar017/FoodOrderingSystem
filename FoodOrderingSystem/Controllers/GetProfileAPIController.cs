using AutoMapper;
using FoodOrderingSystem.Context;
using FoodOrderingSystem.DB;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.View_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GetProfileAPIController : ControllerBase
    {
        IConfiguration _config;
        ProjectContext _Project;
        IMapper _map;
        public GetProfileAPIController(IConfiguration config, ProjectContext project, IMapper map)
        {
            _config = config;
            _Project = project;
            _map = map;

        }

        [HttpGet]
        [Route("UserProfile")]
        public async Task<List<GetProfile>> UserProfile()
        {
            await Task.Delay(0);
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "UserId"))
            {
                string UserName = currentUser.Claims.FirstOrDefault(c => c.Type == "UserName").Value.ToString();
                List<RegistrationUsers> UserList = _Project.Registration.Where(usr => usr.UserName.Equals(UserName)).ToList();
                List<GetProfile> NewList = _map.Map<List<GetProfile>>(UserList);
                return NewList;

            }
            else
            {
                return null;
            }

            
        }
        
    }
}
