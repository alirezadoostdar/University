using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace Uninversity.Infarstructure.FluentApiMa;

public class ClassConfig : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.ToTable("Classes");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.CourseId)
            .IsRequired();

        builder.Property(c => c.TeacherId)
            .IsRequired();

        builder.Property(c => c.SemesterId)
            .IsRequired();

        builder.Property(c => c.Capacity)
            .IsRequired();

        builder.HasOne(c => c.Course)
            .WithMany(c => c.Classes)
            .HasForeignKey(c => c.CourseId);

        builder.HasOne(c => c.Teacher)
            .WithMany(t => t.Classes)
            .HasForeignKey(c => c.TeacherId);

        builder.HasOne(c => c.Semester)
            .WithMany(s => s.Classes)
            .HasForeignKey(c => c.SemesterId);

        builder.HasMany(c => c.Schedules)
            .WithOne(c => c.Class)
            .HasForeignKey(c => c.ClassId);
    }
}
