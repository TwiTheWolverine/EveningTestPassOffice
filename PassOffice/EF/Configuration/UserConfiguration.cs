using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassOffice.EF.Entity;

namespace PassOffice.EF.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired();
		builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired();
		builder.Property(x => x.MiddleName).HasColumnName("MiddleName");

		builder.Property(x => x.Description).HasColumnName("Description");

		builder.ToTable("User");
	}
}