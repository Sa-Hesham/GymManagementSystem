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
    internal class MembersBookingSessionsConfiguratins : IEntityTypeConfiguration<MembersBookingSessions>
    {
        public void Configure(EntityTypeBuilder<MembersBookingSessions> builder)
        {
            builder.Ignore(x => x.Id);
            builder.HasKey(x => new { x.SessionId, x.MemberId });
            builder.Property(x => x.CreatedAt)
                .HasColumnName("BookingDate")
               .HasDefaultValueSql("GETDATE()") ;

            builder.HasOne(b => b.Member)
                .WithMany(m => m.MembersBooking)
                .HasForeignKey(b => b.MemberId);


            builder.HasOne(b => b.sessions)
             .WithMany(m => m.BookingSessions)
             .HasForeignKey(b => b.SessionId);


        }
    }
}
