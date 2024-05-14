using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Svatk.Domain.Entity;

namespace Svatk.DAL.Configure;

public class ProfileConfigure : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Adress).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Age).HasMaxLength(100).IsRequired();

        builder.HasOne(x => x.Balance)
            .WithOne(x => x.Profile)
            .HasForeignKey<Balance>("ProfileId")
            .HasPrincipalKey<Profile>(x => x.Id);
        
        builder.HasData(new Profile()
        {
            Id = 1,
            Adress = "Улица",
            Age = 24,
            UserId = 1,
        });
    }
}