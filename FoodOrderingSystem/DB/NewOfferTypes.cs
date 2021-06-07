using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.DB
{
    public class NewOfferTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewOfferTypeId { get; set; }
        public string NewOfferTypeTitle { get; set; }
        public int NewOfferTypeStatus { get; set; }
        public DateTime InsertionDateTime { get; set; }
    }
}
