using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace Uninversity.Infarstructure.FluentApiMap;

public class PersonEntityMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasColumnName("Name")
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasColumnName("Family")
            .IsRequired();

        builder.OwnsOne(p => p.ContactInfo, c =>
        {
            c.Property(x => x.PhoneNumber)
            .HasColumnName("PhoneNumber")
            .HasMaxLength(15)
            .IsRequired(true);

            c.Property(x => x.Address)
            .HasColumnName("Address")
            .HasMaxLength(200)
            .IsRequired(false);
        });

        builder.HasDiscriminator<PersonType>("PersonType")
            .HasValue<Student>(PersonType.Student)
            .HasValue<Teacher>(PersonType.Teacher);

        builder.Property("PersonType")
            .HasColumnName("Type")
            .IsRequired();
    }
}
