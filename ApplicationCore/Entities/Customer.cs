﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Customer: BaseEntity
    {
        //public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }  // navigation property
        public string Location { get; set; }
        public string Locale { get; set; }
        public string Gender { get; set; }
    }
}