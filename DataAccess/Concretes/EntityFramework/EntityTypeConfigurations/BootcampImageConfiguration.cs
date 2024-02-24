﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class BootcampImageConfiguration : IEntityTypeConfiguration<BootcampImage>
{
    public void Configure(EntityTypeBuilder<BootcampImage> builder)
    {
        builder.ToTable("BootcampImages").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.BootcampId).HasColumnName("BootcampId");
        builder.Property(x => x.ImagePath).HasColumnName("ImagePath");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Bootcamp);
    }
}
