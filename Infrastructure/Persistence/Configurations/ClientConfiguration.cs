using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace Infrastructure.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.ToTable("Client");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                    .HasMaxLength(120)
                    .IsRequired();
            builder.Property(t => t.Email)
                    .HasMaxLength(120)
                    .IsRequired();
            builder.Property(t => t.Phone)
                    .HasMaxLength(30);


        }
    }
}