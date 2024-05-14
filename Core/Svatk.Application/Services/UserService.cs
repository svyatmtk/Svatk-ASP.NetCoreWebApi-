using Microsoft.EntityFrameworkCore;
using Svatk.DAL;
using Svatk.Domain;
using Svatk.Domain.Entity;
using Svatk.Domain.Interfaces.Repository;
using Svatk.Domain.Interfaces.Services;
using Svatk.Domain.Result;

namespace Svatk.Application.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IBaseRepository<User> _userRepository;
    private readonly IBaseRepository<Profile> _profileRepository;
    private readonly IBaseRepository<Balance> _balanceRepository;
    private readonly IBaseRepository<Role> _roleRepository;

    public UserService(IBaseRepository<User> userRepository, IBaseRepository<Profile> profileRepository,
        IBaseRepository<Balance> balanceRepository, ApplicationDbContext dbContext, IBaseRepository<Role> roleRepository)
    {
        _userRepository = userRepository;
        _profileRepository = profileRepository;
        _balanceRepository = balanceRepository;
        _dbContext = dbContext;
        _roleRepository = roleRepository;
    }

    public async Task<CollectionResult<UserDto>> GetUsersAsync()
    {
        var role = await _roleRepository.GetAll()
            .FirstOrDefaultAsync(x => x.Name == "Moderator");

        var user = await _userRepository.GetAll()
            .FirstOrDefaultAsync(x => x.Id == 3);

        var userRole = user.Roles;

        await _dbContext.Entry(user).Collection(x => x!.Roles).LoadAsync();

        if (role != null)
        {
            user.Roles.Add(role);
            _userRepository.Update(user);
            await _userRepository.SaveChangeAsync();
        }

        userRole = user.Roles;
        
        UserDto[] userDto = new UserDto[5];
        return new CollectionResult<UserDto>()
        {
            Data = userDto,
            Count = 0
        };
    }
}