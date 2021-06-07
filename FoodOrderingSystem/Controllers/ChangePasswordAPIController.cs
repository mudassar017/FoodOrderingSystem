﻿using AutoMapper;
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
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodOrderingSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordAPIController : ControllerBase
    {
        IConfiguration _config;
        ProjectContext _Project;
        IMapper _map;
        public ChangePasswordAPIController(IConfiguration config, ProjectContext project, IMapper map)
        {
            _config = config;
            _Project = project;
            _map = map;

        }
        //Api To Change User Password
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<Response> ChangeUserPassword(ChangePasswordModal password)
        {
            await Task.Delay(0);
            Response res = new Response();
            //var identity = User.Identity as ClaimsIdentity;
            //if (identity != null)
            //{
            //    IEnumerable<Claim> claims = identity.Claims;
            //    var name = claims.Where(p => p.Type == "UserId").FirstOrDefault()?.Value;var name = claims.Where(p => p.Type == "UserId").FirstOrDefault()?.Value;
            //    res.status = name;
            //}
            try
            {
                if (password.OldPassword is null or "" || password.NewPassword is null or "")
                {
                    res.status = "Please Fill All Fields";
                }
                else
                {



                    var currentUser = HttpContext.User;
                    if (currentUser.HasClaim(c => c.Type == "UserId"))
                    {
                        //string UserId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value.ToString();
                        //string UserName = currentUser.Claims.FirstOrDefault(c => c.Type == "UserName").Value.ToString();
                        //var oldPassword = EncryptDecrypt.Encrypt(password.OldPassword);
                        //RegistrationUsers newuser = _map.Map<RegistrationUsers>(UserId, oldPassword);
                        //RegistrationUsers checkpassword = _Project.Registration.Where(checkpassword => checkpassword.RegistrationId.Equals(UserId)) && checkpassword.Password.Equals(oldPassword).FirstOrDefault();
                        //if (checkpassword == default(RegistrationUsers))
                        //{
                        //    res.status = "Old Password Not Matched";
                        //}
                        //else
                        //{
                        //    checkpassword.Password = password.NewPassword;
                        //    _Project.Registration.Add(checkpassword);
                        //    _Project.SaveChanges();
                        //    res.status = "Password Changed Successfully";
                        //}
                    }
                    else
                    {
                        return null;
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
