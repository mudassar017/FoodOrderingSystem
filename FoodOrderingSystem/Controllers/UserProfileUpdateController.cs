using AutoMapper;
using FoodOrderingSystem.Context;
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
    public class UserProfileUpdateController : ControllerBase
    {
        IConfiguration _config;
        ProjectContext _Project;
        IMapper _map;
        public UserProfileUpdateController(IConfiguration config, ProjectContext project, IMapper map)
        {
            _config = config;
            _Project = project;
            _map = map;

        }
        //Api To Change User Password
        [HttpPost]
        [Route("UpdateUserProfile")]
        public async Task<Response> UpdateUserProfile(UpdateProfileModel update )
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {

                if (update.Name is null or "" || update.Address is null or "")
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
                        

                        var updateProfile = _Project.Registration.Where(s => s.UserName.Equals(UserName)).SingleOrDefault();

                        updateProfile.Name = update.Name;
                        updateProfile.Address = update.Address;
                            _Project.Registration.Update(updateProfile);
                            _Project.SaveChanges();
                            res.status = "ProfileUpdated Successfully";
                        
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
