using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace Uninversity.Infarstructure.FluentApiMap;

public class ClassEnrollmentConfig : IEntityTypeConfiguration<ClassEnrollment>
{
    public void Configure(EntityTypeBuilder<ClassEnrollment> builder)
    {
        builder.ToTable("ClassEnrollments");

        builder.HasKey(e => new { e.ClassId, e.StudentId });

        builder.Property(e => e.ClassId)
            .HasColumnName("ClassId")
            .IsRequired();

        builder.Property(e => e.StudentId)
            .HasColumnName("StudentId")
            .IsRequired();


    }
}
