using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ExpenceTrackerWebApp.Models;

namespace ExpenceTrackerWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ExpenceTrackerWebApp.Models.Income> Income { get; set; }
        public DbSet<ExpenceTrackerWebApp.Models.Expence> Expence { get; set; }
    }
}
