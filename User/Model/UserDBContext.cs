using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Users.Model
{
    public class UserDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local);Database=UserDB;Trusted_Connection=True");
        }

        public DbSet<UserDB> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserDB>()
        //        .HasKey(b => b.Id);
        //}
    }
}
