using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.DB
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }
        public int MenuId { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public int FoodPrice { get; set; }
        public DateTime RatingonFood { get; set; }
        public DateTime InsertionDateTime { get; set; }
    }
}
