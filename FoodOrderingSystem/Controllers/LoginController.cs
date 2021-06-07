using AutoMapper;
using FoodOrderingSystem.Context;
using FoodOrderingSystem.DB;
using FoodOrderingSystem.EncryptionDecryptionClass;
using FoodOrderingSystem.Management_Classes;
using FoodOrderingSystem.Models;
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
          public Response LoginUser(LoginModel lgn)
          {
              Response res = new Response();

              

              try
              {
                RegistrationUser userMatch = _map.Map<RegistrationUser>(lgn);
                RegistrationUser userData = _Project.Registrations.Where(userData => userData.Email.Equals(lgn.Email) && userData.Password.Equals(EncryptDecrypt.Encrypt(lgn.Password))).FirstOrDefault();

                if (userData == default(RegistrationUsers))
                {
                    res.status = "Invalid UserName/Password";
                }
                else
                {
                    res.status = "Login Successfull";
                    res.Token = JWT_s.GenerateJSONWebToken(userData, _config);
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
