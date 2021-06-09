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
            try
            {
                if (password.Password is null or "" || password.NewPassword is null or "")
                {
                    res.status = "Please Fill All Fields";
                }
                else
                {

                    var currentUser = HttpContext.User;
                    if (currentUser.HasClaim(c => c.Type == "UserId"))
                    {
                        string UserId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value.ToString();
                        string UserName = currentUser.Claims.FirstOrDefault(c => c.Type == "UserName").Value.ToString();
                        var oldPassword = EncryptDecrypt.Encrypt(password.Password);
                        
                        var checkpassword = _Project.Registration.Where(s=> s.UserName.Equals(UserName) && s.Password.Equals(oldPassword)).SingleOrDefault();
                        if (checkpassword ==null)
                        {
                            res.status = "Old Password Not Matched";
                        }
                        else
                        {
                            checkpassword.Password = password.NewPassword;
                            _Project.Registration.Update(checkpassword);
                            _Project.SaveChanges();
                            res.status = "Password Changed Successfully";
                        }
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
