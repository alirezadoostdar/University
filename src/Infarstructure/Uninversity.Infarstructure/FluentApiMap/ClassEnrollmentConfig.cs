using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace Uninversity.Infarstructure.FluentApiMap;

public class ClassEnrollmentConfig : IEntityTypeConfiguration<ClassEnrollment>
{
    public void Configure(EntityTypeBuilder<ClassEnrollment> builder)
    {
        builder.ToTable("StudentsClasses");

        builder.HasKey(e => new { e.ClassId, e.StudentId });

        builder.Property(e => e.ClassId)
            .HasColumnName("ClassId")
            .IsRequired();

        builder.Property(e => e.StudentId)
            .HasColumnName("StudentId")
            .IsRequired();

        builder.HasOne(e => e.Student)
            .WithMany(e => e.ClassEnrollments)
            .HasForeignKey(e => e.StudentId);

        builder.HasOne(e => e.Class)
            .WithMany(e => e.ClassEnrollments)
            .HasForeignKey(_ => _.ClassId);


    }
}
