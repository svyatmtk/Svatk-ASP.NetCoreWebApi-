using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Svatk.Domain.Entity;

namespace Svatk.DAL.Configure;

public class RoleConfigure : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

        builder.HasData(new List<Role>()
        {
            new Role()
            {
                Id = 1,
                Name = "User",
            },

            new Role()
            {
                Id = 2,
                Name = "Admin"
            },
            new Role()
            {
                Id = 3,
                Name = "Moderator"
            }
        });
    }
}