using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace Uninversity.Infarstructure.FluentApiMap;

public class ClassSchedulesEntityMap : IEntityTypeConfiguration<ClassSchedule>
{
    public void Configure(EntityTypeBuilder<ClassSchedule> builder)
    {
        builder.ToTable("Sections");

        builder.HasKey(x => x.Id);
    }
}
