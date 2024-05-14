using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Svatk.Domain.Entity;

namespace Svatk.DAL.Configure;

public class UserConfigure : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Login).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(100).IsRequired();

        builder.HasOne(x => x.Profile)
            .WithOne(x => x.User)
            .HasForeignKey<Profile>(x => x.UserId)
            .HasPrincipalKey<User>(x => x.Id);

        builder.HasMany(x => x.Roles)
            .WithMany(x => x.Users);
        
        builder.HasData(new User()
        {
            Id = 1,
            Login = "svyatmtk",
            Password = "password",
            CreatedAt = DateTime.UtcNow
        });
    }
}