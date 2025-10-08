using GymDataAccsess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Data.ConFigurations
{
    internal class CategoryConfiguraions : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                  .HasColumnType("varchar")
                  .HasMaxLength(20);


            builder.Ignore(c => c.CreatedAt);
            builder.Ignore(c => c.UpdatedAt);

        }
    }
}
