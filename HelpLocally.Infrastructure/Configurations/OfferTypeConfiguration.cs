
using HelpLocally.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpLocally.Infrastructure.Configurations
{
    public class OfferTypeConfiguration : IEntityTypeConfiguration<OfferType>
    {
        public void Configure(EntityTypeBuilder<OfferType> builder)
        {
            builder.ToTable("OfferTypes");
        }
    }
}
