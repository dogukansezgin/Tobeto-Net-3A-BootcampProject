using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class InstructorImageConfiguration : IEntityTypeConfiguration<InstructorImage>
{
    public void Configure(EntityTypeBuilder<InstructorImage> builder)
    {
        builder.ToTable("InstructorImages").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.InstructorId).HasColumnName("InstructorId");
        builder.Property(x => x.ImagePath).HasColumnName("ImagePath");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Instructor);
    }
}
