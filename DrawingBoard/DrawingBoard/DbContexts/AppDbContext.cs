using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using DrawingBoard.Models;

namespace DrawingBoard.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            //Database.Migrate();
            //Database.EnsureCreated();
        }
        public virtual DbSet<User> Users { get; set; } = default!;
        public virtual DbSet<Drawing> Drawings { get; set; } = default!;
        public virtual DbSet<Board> Boards { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new SuperAdminConfiguration());
        }
    }
}
