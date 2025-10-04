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
    internal class TrainerConfiguration : GymUserConfigurations<Trainer>, IEntityTypeConfiguration<Trainer>
    {
        public  new void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(T => T.CreatedAt)
                .HasColumnName("HiringDate")
                .HasDefaultValueSql("GETDATE()");

            builder.Ignore(T => T.UpdatedAt);

            builder.Property(T => T.Specialies)
                .HasConversion<string>()
                .HasMaxLength(12);


                base.Configure(builder);
        }
    }
}
