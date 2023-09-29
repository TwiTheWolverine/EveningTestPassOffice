using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassOffice.EF.Entity;

namespace PassOffice.EF.Configuration;

public class PassConfiguration : IEntityTypeConfiguration<Pass>
{
	public void Configure (EntityTypeBuilder<Pass> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Status).HasColumnName("StatusId").IsRequired();
		builder.Property(x => x.Type).HasColumnName("TypeId").IsRequired();
		builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();

		builder.Property(x => x.IssueDate).HasColumnName("IssueDate").IsRequired();
		builder.Property(x => x.ValidFrom).HasColumnName("ValidFrom").IsRequired();
		builder.Property(x => x.ValidTo).HasColumnName("ValidTo");

		builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired();

		builder.ToTable("Pass");
	}
}