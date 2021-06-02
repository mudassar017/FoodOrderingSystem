using FoodOrderingSystem.Context;
using FoodOrderingSystem.DB;
using FoodOrderingSystem.EncryptionDecryptionClass;
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
    public class RegistrationController : ControllerBase
    {
        IConfiguration _config;
        ProjectContext _Project;
        public RegistrationController(IConfiguration config, ProjectContext project)
        {
            _config = config;
            _Project = project;

        }
        [HttpPost]

        [Route("Registration")]
        public Response Registration(RegistrationUser obj)
        {
            Response res = new Response();
            try
            {
                RegistrationUser newRegistrationUser = new RegistrationUser();

                newRegistrationUser.status = 1;
             //   EncryptDecrypt.Base64Encode(newRegistrationUser.Password);
                _Project.Registrations.Add(newRegistrationUser);
                _Project.SaveChanges();
                res.status = "Insertion successfull";


            }
            catch (Exception ex)
            {
                res.status = ex.Message;
            }
            return res;
        }

        [HttpGet]
        [Route("GetRegistration")]
        public List<RegistrationUser> GetRegistration()
        {
            List<RegistrationUser> RegistrationList = _Project.Registrations.Where(std => std.status == 1).ToList();
            return RegistrationList;
        }
    }
}