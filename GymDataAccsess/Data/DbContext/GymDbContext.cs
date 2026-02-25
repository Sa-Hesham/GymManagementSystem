using GymDataAccsess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Data
{
   public class GymDbContext :IdentityDbContext<ApplicationUser>

    {
       

        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
        }

       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<ApplicationUser>(eb =>
            {
                eb.Property(x => x.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(50);


                eb.Property(x => x.LastName)
               .HasColumnType("varchar")
               .HasMaxLength(50);
            });
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
