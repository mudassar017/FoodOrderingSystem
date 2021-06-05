using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.DB
{
    public class NewOffers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewOfferId { get; set; }
        public int NewOfferTypeId { get; set; }
        public string NewOfferTite { get; set; }
        public string NewOfferDescription { get; set; }
        public int NewOfferPrice { get; set; }
        public int NewOfferStatus { get; set; }
        public DateTime InsertionDateTime { get; set; }
    }
}
