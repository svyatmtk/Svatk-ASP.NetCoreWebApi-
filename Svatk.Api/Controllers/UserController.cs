using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Svatk.Domain.Entity;
using Svatk.Domain.Interfaces.Services;
using Svatk.Domain.Result;

namespace Svatk.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CollectionResult<User>>> GetUsers()
    {
        var users = await _userService.GetUsersAsync();

        if (users.IsSuccess)
        {
            return Ok(users);
        }

        return BadRequest();
    }
}