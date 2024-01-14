using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSchool.Students.Domain.Models;

namespace SmartSchool.Students.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Ignore(x => x.Age);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(70);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(70);
        builder.Property(x => x.Email).HasMaxLength(70);


    }
}
