using GymDataAccsess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Data
{
   public class GymDbContext :DbContext

    {
       

        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=. ; Database=GymSystem ; Trusted_Connection=True ;TrustServerCertificate=True");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> trainers{ get; set; }
        public DbSet<Plan> Plans { get; set; }

        public DbSet<Category>categories { get; set; }

        public DbSet<Sessions> sessions { get; set; }


        public DbSet<MemberShip> MemberShips { get; set; }

        public DbSet<MembersBookingSessions> membersBookingSessions { get; set; }









    }
}
