using AutoMapper;
using FoodOrderingSystem.Context;
using FoodOrderingSystem.DB;
using FoodOrderingSystem.Management_Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IConfiguration _config;
        ProjectContext _Project;
        IMapper _map;
        public LoginController(IConfiguration config, ProjectContext project, IMapper map)
        {
            _config = config;
            _Project = project;
            _map = map;

        }
        [HttpPost]
        [Route("LoginStudent")]
        public Response LoginStudent(RegistrationUser lgn)
        {
            Response res = new Response();
            try
            {
                RegistrationUser std= _Project.Registrations.Where(std => std.Email.Equals(lgn.Email) && std.Password.Equals(lgn.Password)).FirstOrDefault();
                if (std == default(RegistrationUser))
                {
                    res.Token = "Invalid  UserName/Password";
                }
                else
                {
                    res.Token = JWT_s.GenerateJSONWebToken(std, _config);
                    

                }
            }
            catch
            {
                res.status = "Failed";
            }
            return res;
        }


    }
}
