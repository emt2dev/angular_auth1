﻿using AngularAuthAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AngularAuthAPI.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users"); // adds to DB table named users
            base.OnModelCreating(modelBuilder);
        }
    }
}
