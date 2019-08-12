using System;
using System.Collections.Generic;
using System.Text;
using BChat.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BChat.Data.EntityFramework
{
    public class BasicContext : DbContext
    {
        private string _connectionString = "DefaultConnection";

        public DbSet<Message> Messages { get; set; }

        public BasicContext(DbContextOptions options) : base(options)
        {

        }

        public BasicContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
