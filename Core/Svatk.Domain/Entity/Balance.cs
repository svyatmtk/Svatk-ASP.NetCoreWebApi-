using Svatk.Domain.Interfaces;

namespace Svatk.Domain.Entity;

public class Balance : IEntity<long>
{
    public long Id { get; set; }

    public decimal Amount { get; set; }
    
    public Profile Profile { get; set; }
}