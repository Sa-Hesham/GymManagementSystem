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
    internal class SessionConfigurations : IEntityTypeConfiguration<Sessions>
    {
        public void Configure(EntityTypeBuilder<Sessions> builder)
        {
            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("CapcityCheak", "Capcity between 1 And 25");
                tb.HasCheckConstraint("EnddateCheak", "EndDate>StartDate");

            });




            #region Category-seesion(realtion) 

            builder.HasOne(s => s.SessionCategory)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.CategoryId);



            #endregion


            #region Trainer-Session(Relation)
            builder.HasOne(s=>s.TrainerSession)
                .WithMany(t=>t.Sessions)
                .HasForeignKey(s=>s.TrainerId);
            #endregion
        }
    }
}
