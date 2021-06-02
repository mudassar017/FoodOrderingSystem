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
            CreateMap<InsertionModel, RegistrationUser>();
            CreateMap<GetModel, RegistrationUser>().ReverseMap();
        }
    }
}
