using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.View_Model
{
    public class UpdateProfileModel
    {
        public string Name { get; set; }
        
        public string Address { get; set; }
    }
}
