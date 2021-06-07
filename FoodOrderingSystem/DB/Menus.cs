using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.DB
{
    public class Menus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }
        public string MenuTitle { get; set; }
        public int Status { get; set; }
        public DateTime InsertionDateTime { get; set; }
    }
}
