using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("Reports").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.Title).HasColumnName("Title");
        builder.Property(r => r.Link).HasColumnName("Link");
        builder.Property(r => r.Description).HasColumnName("Description");
        builder.Property(ar => ar.ReportDate).HasColumnName("ReportDate");
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);

        builder.HasOne(r => r.AiReport) 
                .WithOne(ar => ar.Report) 
                .HasForeignKey<AiReport>(ar => ar.ReportId); 
    }
}