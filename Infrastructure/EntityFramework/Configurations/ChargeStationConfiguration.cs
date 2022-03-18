using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

class ChargeStationConfiguration : IEntityTypeConfiguration<ChargeStation>
{
    public void Configure(EntityTypeBuilder<ChargeStation> builder)
    {
        builder.HasMany(o => o.Connectors)
            .WithOne(p => p.ChargeStation)
            .HasForeignKey(o => o.ChargeStationId);
        
        //For Reduction in storage and performance improvement, I set the column type to varchar and limited the length of data
        builder.Property(e => e.Name).HasColumnType("varchar(150)").IsRequired();
    }
}