﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.DB
{
    public class RegistrationUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int RegistrationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public string Password { get; set; }
        public int status { get; set; }

        internal void EncryptDecrypt()
        {
            throw new NotImplementedException();
        }
    }
}
