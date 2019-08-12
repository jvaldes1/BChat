using System;
using System.Collections.Generic;
using System.Text;
using BChat.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BChatServer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Message> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
