using Svatk.Domain.Interfaces;

namespace Svatk.Domain.Entity;

public class Role : IEntity<long>
{
    public long Id { get; set; }

    public string Name { get; set; }
    
    public List<User> Users { get; set; }
}