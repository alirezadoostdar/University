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

        builder.HasKey(c => c.Id)
            .HasName("Id");

        builder.Property(c => c.CourseId)
            .HasColumnName("CourseId")
            .IsRequired();

        builder.Property(c => c.TeacherId)
            .HasColumnName("TeacherId")
            .IsRequired();

        builder.Property(c => c.SemesterId)
            .HasColumnName("TermId")
            .IsRequired();

        builder.Property(c => c.Capacity)
            .HasColumnName("Capacity")
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
