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
    internal class MemberShipConfiguration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
            builder.HasOne(ms => ms.Member)
                .WithMany(m => m.memberPlans)
                .HasForeignKey(ms => ms.MemberId);

            builder.HasOne(ms => ms.Plan)
               .WithMany(p => p.MemberPlan)
               .HasForeignKey(ms => ms.PlanId);

            builder.HasKey(ms => new { ms.PlanId, ms.MemberId });


            builder.Property(ms => ms.CreatedAt)
                .HasColumnName("StartedDate")
                .HasDefaultValueSql("GETDATE()");


            builder.Ignore(m => m.Id);
            builder.Ignore(m => m.UpdatedAt);




        }
    }
}
