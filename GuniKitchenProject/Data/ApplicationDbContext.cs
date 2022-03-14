using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GuniKitchenProject.Models;

namespace GuniKitchenProject.Data
{
    public class ApplicationDbContext 
        : IdentityDbContext< MyIdentityUser, MyIdentityRole, Guid>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
             
        }
    }
}
    