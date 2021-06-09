using AutoMapper;
using FoodOrderingSystem.Context;
using FoodOrderingSystem.DB;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.View_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.OLE.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsAPIController : ControllerBase
    {
        IConfiguration _config;
        ProjectContext _Project;
        IMapper _map;
        public FoodItemsAPIController(IConfiguration config, ProjectContext project, IMapper map)
        {
            _config = config;
            _Project = project;
            _map = map;

        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetMenuFood")]
        public async Task<IEnumerable<Object>> GetMenuFood()
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                var FoodMenu = (from fod in _Project.Food
                              join std in _Project.Menu on fod.MenuId equals std.MenuId
                              select new
                              {
                                  MenuTitle = std.MenuTitle,
                                  FoodName = fod.FoodName,
                                  FoodDescription = fod.FoodDescription,
                                  FoodPrice = fod.FoodPrice,
                                  FoodStatus = fod.FoodStatus,
                                  Rating = fod.RatingonFood,
                              }).ToList();

                return FoodMenu;
            }
            catch
            {
                return null;
            }
            
        }

        [HttpPost]
        [Route("InsertMenuFood")]
        public async Task<Response> InsertMenuFood(FoodModel food)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                if (food.FoodName is null or "" )
                {

                    res.status = "Please Fill All Required Fields.";
                }
                else
                {
                    Foods NewFood = _map.Map<Foods>(food);
                    NewFood.FoodStatus = 1;
                    NewFood.InsertionDateTime = DateTime.Now;
                    _Project.Food.Add(NewFood);
                    _Project.SaveChanges();
                    res.status = "Food Item Added";
                }

            }
            catch (Exception ex)
            {
                 res.status = ex.Message;
            }
            return res;

        }


       
        [HttpGet]
        [Route("GetMenu")]
        public async Task<List<GetMenuModel>> GetMenu()
        {
            await Task.Delay(0);
            try
            {
                List<Menus> MenuItems = _Project.Menu.Where(MenuItems => MenuItems.Status == 1).ToList();
                List<GetMenuModel> Items = _map.Map<List<GetMenuModel>>(MenuItems);
                return Items;
            }
            catch
            {
                return null;
            }

        }


        [HttpPost]
        [Route("InsertMenu")]
        public async Task<Response> InsertMenu(MenuModel menu)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                if (menu.MenuTitle is null or "")
                {

                    res.status = "Please Fill All Required Fields.";
                }
                else
                {
                    Menus NewMenu = _map.Map<Menus>(menu);
                    NewMenu.Status = 1;
                    NewMenu.InsertionDateTime = DateTime.Now;
                    _Project.Menu.Add(NewMenu);
                    _Project.SaveChanges();
                    res.status = "Menu Item Added";
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
