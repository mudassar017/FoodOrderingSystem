using AutoMapper;
using FoodOrderingSystem.Context;
using FoodOrderingSystem.DB;
using FoodOrderingSystem.EncryptionDecryptionClass;
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
    public class RegistrationController : ControllerBase
    {
        IConfiguration _config;
        ProjectContext _Project;
        IMapper _map;
        public RegistrationController(IConfiguration config, ProjectContext project, IMapper map)
        {
            _config = config;
            _Project = project;
            _map = map;

        }
        [HttpPost]

        [Route("Registration")]
        public Response Registration(InsertionModel obj)
        {
            Response res = new Response();

            try
            {
                RegistrationUser newUser = _map.Map<RegistrationUser>(obj);


                newUser.status = 1;
             //   EncryptDecrypt.Base64Encode(newRegistrationUser.Password);
                _Project.Registrations.Add(newUser);
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
        public List<GetModel> GetRegistration()
        {
            List<RegistrationUser> RegistrationList = _Project.Registrations.Where(std => std.status == 1).ToList();
            List<GetModel> NewList = _map.Map<List<GetModel>>(RegistrationList);
            return NewList;
        }
    }
}