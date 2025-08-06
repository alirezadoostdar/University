using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace Uninversity.Infarstructure.FluentApiMap;

public class SemesterEntityConfig : IEntityTypeConfiguration<Semester>
{
    public void Configure(EntityTypeBuilder<Semester> builder)
    {
        builder.ToTable("Terms");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Active)
            .HasColumnName("IsActive")
            .IsRequired();
    }
}
