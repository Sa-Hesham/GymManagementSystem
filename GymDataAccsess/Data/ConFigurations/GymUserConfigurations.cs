using GymDataAccsess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Data.ConFigurations
{
    internal class GymUserConfigurations<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(b => b.Name)
                  .HasColumnType("varchar")
                  .HasMaxLength(50);

            


            builder.Property(b => b.Email)
                .HasMaxLength(100);

            builder.HasIndex(builder => builder.Email)
                .IsUnique();

            builder.HasIndex(builder=> builder.Phone)
                .IsUnique();

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("CheakOnEmail", "Email Like '_%@_%._%'");
                tb.HasCheckConstraint("cheakOnPhone", "Phone Like '01%' And LEN(Phone) = 11 AND Phone Not Like '%[^0-9]%'");

            });

            builder.Property(user => user.Gendar)
                .HasConversion<string>()
                .HasMaxLength(6)
                .IsRequired();


            //Adress Configurations

            builder.OwnsOne(b => b.Address, Address =>
            {
                Address.Property(a => a.street)
                .HasColumnName("Street")
                .HasColumnType("varchar")
                .HasMaxLength(30);

                Address.Property(a => a.city)
                .HasColumnName("City")
               .HasColumnType("varchar")
               .HasMaxLength(30);



                Address.Property(a => a.BuildingNumber)
               .HasColumnName("BuildingNumber");






            });

             
        }
    }
}
