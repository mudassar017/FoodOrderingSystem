using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.DB
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int RegistratiodnId { get; set; }
        public int NewOfferId { get; set; }
        public int OrderPrice { get; set; }
        public int OrderStatus { get; set; }
        public DateTime OrderDateTime { get; set; }
        
    }
}
