using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.ApplicantId).HasColumnName("ApplicantId");
        builder.Property(x => x.BootcampId).HasColumnName("BootcampId");
        builder.Property(x => x.ApplicationStateId).HasColumnName("ApplicationStateId");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Applicant)
            .WithMany()
            .HasForeignKey(x => x.ApplicantId);
        builder.HasOne(x => x.Bootcamp)
            .WithMany()
            .HasForeignKey(x => x.BootcampId);
        builder.HasOne(x => x.ApplicationState)
            .WithMany()
            .HasForeignKey(x => x.ApplicationStateId);
    }
}
