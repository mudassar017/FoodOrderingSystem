using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.View_Model
{
    public class FoodModel
    {
        public int FoodId { get; set; }
        public int MenuId { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public int FoodPrice { get; set; }
        public int RatingonFood { get; set; }
    }
}
