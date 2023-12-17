using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AiReportConfiguration : IEntityTypeConfiguration<AiReport>
{
    public void Configure(EntityTypeBuilder<AiReport> builder)
    {
        builder.ToTable("AiReports").HasKey(ar => ar.Id);

        builder.Property(ar => ar.Id).HasColumnName("Id").IsRequired();
        builder.Property(ar => ar.ReportId).HasColumnName("ReportId");
        builder.Property(ar => ar.SideA).HasColumnName("SideA");
        builder.Property(ar => ar.SideB).HasColumnName("SideB");
        builder.Property(ar => ar.CasualtiesA).HasColumnName("CasualtiesA");
        builder.Property(ar => ar.CasualtiesB).HasColumnName("CasualtiesB");
        builder.Property(ar => ar.CasualtiesAll).HasColumnName("CasualtiesAll");
        builder.Property(ar => ar.CasualtiesCivilian).HasColumnName("CasualtiesCivilian");
        builder.Property(ar => ar.Country).HasColumnName("Country");
        builder.Property(ar => ar.City).HasColumnName("City");
        builder.Property(ar => ar.Region).HasColumnName("Region");
        builder.Property(ar => ar.Source).HasColumnName("Source");
        builder.Property(ar => ar.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ar => ar.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ar => ar.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ar => !ar.DeletedDate.HasValue);

        builder.HasOne(ar => ar.Report)
            .WithOne(r => r.AiReport)
            .HasForeignKey<AiReport>(ar => ar.ReportId);
    }
}