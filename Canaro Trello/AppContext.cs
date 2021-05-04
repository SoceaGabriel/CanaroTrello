using Canaro_Trello.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Canaro_Trello
{
    public class AppContext : DbContext
    {
        public DbSet<User> Utilizatori { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public AppContext() : base("name=CanaroConnection")
        {
        }

        public static AppContext Create()
        {
            return new AppContext();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}