using Svatk.Domain.Interfaces;

namespace Svatk.Domain.Entity;

public class User : IEntity<long>, IAuditable
{
    public long Id { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public List<Role> Roles { get; set; }
    
    public Profile Profile { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}