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
    internal class PlanConfiguraton : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(P => P.Name)
                 .HasColumnType("varchar")
                 .HasMaxLength(50);

            builder.Property(P => P.Description)
                 .HasColumnType("varchar")
                 .HasMaxLength(100);

            builder.Property(P => P.Price)
                .HasPrecision(10, 2);


            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("plancheak", "DurationDays Between 1 and 365");

            });


            builder.Ignore(P => P.CreatedAt);
            builder.Ignore(P => P.UpdatedAt);

        }
    }
}
