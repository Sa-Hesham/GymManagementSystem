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
    internal class MemberConfiguration : GymUserConfigurations<Member>, IEntityTypeConfiguration<Member>
    {
        public new  void Configure(EntityTypeBuilder<Member> builder)
        {

            builder.Property(a => a.CreatedAt)
               .HasColumnName("JoinDate")
               .HasDefaultValueSql("GETDATE()");

            builder.Ignore(m => m.UpdatedAt);

            base.Configure(builder);


        }
    }
}
