using FoodOrderingSystem.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        public DbSet<RegistrationUsers> Registration { get; set; }
        public DbSet<Foods> Food { get; set; }
        public DbSet<Menus> Menu { get; set; }
        public DbSet<NewOffers> NewOffer { get; set; }
        public DbSet<NewOfferTypes> NewOfferType { get; set; }
        public DbSet<OrderDetails> OrderDetail { get; set; }
        public DbSet<Orders> Order { get; set; }
    }


}
