﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo.Data
{
    public class ZooContext : DbContext
    {
        public ZooContext (DbContextOptions<ZooContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animal { get; set; } = default!;
        public DbSet<Zoo.Models.Enclosure> Enclosure { get; set; } = default!;
        public DbSet<Zoo.Models.Category> Category { get; set; } = default!;
        public DbSet<Zoo.Models.Species> Species { get; set; } = default!;
        public DbSet<Zoo.Models.ZooModel> ZooModel { get; set; } = default!;
    }
}