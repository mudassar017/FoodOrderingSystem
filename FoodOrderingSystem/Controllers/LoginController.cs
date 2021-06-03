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
        RegistrationUser Data = _Project.Registrations.Where(Data => lgn.Email.Equals(Data.Email) && lgn.Password.Equals(Data.Password)).FirstOrDefault();

              try
              {
                  
                  if (Data == default(RegistrationUser))
                  {
                      res.Token = "Invalid  UserName/Password";
                  }
                  else
                  {
                      res.Token = JWT_s.GenerateJSONWebToken(Data, _config);


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
