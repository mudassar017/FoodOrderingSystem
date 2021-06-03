using AutoMapper;
using FoodOrderingSystem.Context;
using FoodOrderingSystem.DB;
using FoodOrderingSystem.EncryptionDecryptionClass;
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
        [AllowAnonymous]
        [HttpPost]

        [Route("RegistrationUser")]
        public Response RegistrationUser(UserRegistrationModel obj)
        {
            Response res = new Response();

            try
            {
                RegistrationUser newUser = _map.Map<RegistrationUser>(obj);


                newUser.status = 1;
                newUser.Password = EncryptDecrypt.Encrypt(newUser.Password);
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
        public async Task< List<GetModel>> GetRegistration()
        {
            await Task.Delay(0);  
            List<RegistrationUser> RegistrationList = _Project.Registrations.Where(std => std.status == 1).ToList();
            List<GetModel> NewList = _map.Map<List<GetModel>>(RegistrationList);
            return NewList;
        }
    }
}