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

        //APi TO Register New User
        [AllowAnonymous]
        [HttpPost]

        [Route("RegistrationUser")]
        public Response RegistrationUser(UserRegistrationModel obj)
        {
            Response res = new Response();

            try
            {
                RegistrationUsers newUser = _map.Map<RegistrationUsers>(obj);
                newUser.status = 1;
                newUser.Password = EncryptDecrypt.Encrypt(newUser.Password);
                newUser.InsertedDateTime = DateTime.Now;
                newUser.UserType = 0;
                _Project.Registration.Add(newUser);
                _Project.SaveChanges();
                res.status = "Insertion successfull";


            }
            catch (Exception ex)
            {
                res.status = ex.Message;
            }
            return res;
        }
        // Api To get User List
        [HttpGet]
        [Route("GetRegistration")]
        public async Task< List<GetModel>> GetRegistration()
        {
            await Task.Delay(0);  
            List<RegistrationUsers> RegistrationList = _Project.Registration.Where(usr => usr.status == 1).ToList();
            List<GetModel> NewList = _map.Map<List<GetModel>>(RegistrationList);
            return NewList;
        }
        // Api To Check UserEmail
        [AllowAnonymous]
        [HttpPost]
        [Route("CheckUserEmail")]
        public async Task<Response> CheckUserEmail(EmailCheckModal email)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                if(email.Email is null or "")
                {
                    res.status = "Please Enter Email";
                }
                else
                {
                    RegistrationUsers emailreg = new RegistrationUsers();
                    emailreg = _map.Map<RegistrationUsers>(email);


                    emailreg = _Project.Registration.Where(s => s.Email.Equals(email.Email)).FirstOrDefault();


                    if(emailreg == default(RegistrationUsers))
                    {
                        res.status = "Available";
                    }else
                    {
                        res.status = "Email Already Exist.";
                    }
                }
                
            }catch(Exception ex)
            {
                res.status = ex.Message;
            }
            return res;
        }
        //Api to Check UserName
        [AllowAnonymous]
        [HttpPost]
        [Route("CheckUserName")]
        public async Task<Response> CheckUserName(UserNameCheckModal username)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                if (username.UserName is null or "")
                {
                    res.status = "Please Enter UserName";
                }
                else
                {
                    RegistrationUsers checkUserName = new RegistrationUsers();
                    checkUserName = _map.Map<RegistrationUsers>(username);
                    checkUserName = _Project.Registration.Where(checkUserName=> checkUserName.UserName.Equals(username.UserName)).FirstOrDefault();
                    if (checkUserName == default(RegistrationUsers))
                    {
                        res.status = "Available";
                    }
                    else
                    {
                        res.status = "UserName Already Exist.";
                    }
                }

            }
            catch (Exception ex)
            {
                res.status = ex.Message;
            }
            return res;
        }
    }
}