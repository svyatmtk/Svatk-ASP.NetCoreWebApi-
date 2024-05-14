using Svatk.Domain.Interfaces;

namespace Svatk.Domain.Entity;

public class Profile : IEntity<long>
{
    public long Id { get; set; }
    
    public string Adress { get; set; }
    
    public int Age { get; set; }
    
    public User User { get; set; }
    
    public long UserId { get; set; }

    public Balance Balance { get; set; }

}