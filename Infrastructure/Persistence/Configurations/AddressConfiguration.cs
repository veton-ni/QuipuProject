using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {

            builder.ToTable("Address");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                    .HasMaxLength(120)
                    .IsRequired();
            builder.Property(t => t.PostCode)
                    .HasMaxLength(6);


            builder.HasOne(x => x.client).WithMany(y => y.ListAddresses).HasForeignKey(x => x.IdClient);
        }
    }
}