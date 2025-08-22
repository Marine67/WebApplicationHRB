using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class DBContext : DbContext
    {
        
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<RoomDetails> roomDetails { get; set; }
    }
}

