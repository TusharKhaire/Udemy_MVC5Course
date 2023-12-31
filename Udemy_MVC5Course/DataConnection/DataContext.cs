﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Udemy_MVC5Course.Entity;
using Udemy_MVC5Course.Models;

namespace Udemy_MVC5Course.DataConnection
{
    public class DataContext : IdentityDbContext<Users>
    {
        public DataContext() : base("Udemy_MVC5Course") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genres> Genres { get; set; }

    
    }
}