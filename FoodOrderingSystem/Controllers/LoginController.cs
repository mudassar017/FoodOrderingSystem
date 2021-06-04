using AutoMapper;
using FoodOrderingSystem.Context;
using FoodOrderingSystem.DB;
using FoodOrderingSystem.Management_Classes;
using FoodOrderingSystem.View_Model;
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
        public Response LoginStudent(LoginModel lgn)
        {
            Response res = new Response();
            RegistrationUser std = _Project.Registrations.Where(std => lgn.Email.Equals(std.Email) && lgn.Password.Equals(std.Password)).FirstOrDefault();
            try
            {
                
                if (std == default(RegistrationUser))
                {
                    res.status = "Invalid  UserName/Password";
                }
                else
                {
                    res.Token = JWT_s.GenerateJSONWebToken(std, _config);
                    res.status = "Login Successfuly";

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
