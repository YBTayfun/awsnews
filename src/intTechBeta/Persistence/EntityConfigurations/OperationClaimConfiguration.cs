using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Reports
        seeds.Add(new OperationClaim { Id = ++id, Name = "Reports.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Reports.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Reports.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Reports.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Reports.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Reports.Delete" });
        #endregion
        #region AiReports
        seeds.Add(new OperationClaim { Id = ++id, Name = "AiReports.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AiReports.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AiReports.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AiReports.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AiReports.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AiReports.Delete" });
        return seeds;
    }
}
