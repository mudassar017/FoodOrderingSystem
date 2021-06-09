using AutoMapper;
using FoodOrderingSystem.DB;
using FoodOrderingSystem.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.IMApping
{
    public class Mapping:Profile
    {
       public Mapping()
        {
            CreateMap<UserRegistrationModel, RegistrationUsers>().ReverseMap();
            CreateMap<GetModel, RegistrationUsers>().ReverseMap();
            CreateMap<LoginModel, RegistrationUsers>().ReverseMap();
            CreateMap<UserNameCheckModal, RegistrationUsers>().ReverseMap();
            CreateMap<EmailCheckModal, RegistrationUsers>().ReverseMap();
            CreateMap<ChangePasswordModal, RegistrationUsers>().ReverseMap();
            CreateMap<GetProfile, RegistrationUsers>().ReverseMap();
            CreateMap<FoodModel, Foods>().ReverseMap();
            CreateMap<MenuModel, Menus>().ReverseMap();
            CreateMap<GetMenuModel, Menus>().ReverseMap();
            
        }
    }
}
