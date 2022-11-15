﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class BesinlerMapping:EntityTypeConfiguration<Besinler>
    {
        public BesinlerMapping()
        {
            this.Property(x => x.CreatedBy).HasMaxLength(25).HasColumnType("nvarchar");
            this.Property(x => x.DeletedBy).HasMaxLength(25).HasColumnType("nvarchar");
            this.Property(x => x.ModifiedBy).HasMaxLength(25).HasColumnType("nvarchar");

            this.HasMany(x => x.TuketilenBesinler)
           .WithOptional(x => x.BesinBilgileri)
           .HasForeignKey(x => x.BesinBilgileriID);
            //++
        }
    }
}
