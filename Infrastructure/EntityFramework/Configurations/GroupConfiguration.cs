using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasMany(o => o.ChargeStations)
            .WithOne(p => p.Group)
            .HasForeignKey(o => o.GroupId);
        
        //For Reduction in storage and performance improvement, I set the column type to varchar and limited the length of data
        builder.Property(e => e.Name).HasColumnType("varchar(150)").IsRequired();
    }
}