using Svatk.Domain.Result;

namespace Svatk.Domain.Interfaces.Services;

public interface IUserService
{
    Task<CollectionResult<UserDto>> GetUsersAsync();
}