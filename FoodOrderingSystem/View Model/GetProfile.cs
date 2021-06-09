using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.View_Model
{
    public class GetProfile
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
       
        public int status { get; set; }
    }
}
