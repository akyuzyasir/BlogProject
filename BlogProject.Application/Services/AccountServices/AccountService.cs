using BlogProject.Domain.Core.BaseEntities;
using BlogProject.Domain.Enums;
using BlogProject.Infrastructure.Repositories.AuthorRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogProject.Application.Services.AccountServices;

public class AccountService : IAccountService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountService(UserManager<IdentityUser> userManager, IAuthorRepository authorRepository)
    {
        _userManager = userManager;
        _authorRepository = authorRepository;
    }

    public async Task<bool> AnyAsync(Expression<Func<IdentityUser, bool>> expression)
    {
        return await _userManager.Users.AnyAsync(expression);
    }

    public async Task<IdentityResult> CreateUserAsync(IdentityUser user, Roles role)
    {
        var result = await _userManager.CreateAsync(user, "Password.1");
        if(!result.Succeeded)
        {
            return result;
        }
        return await _userManager.AddToRoleAsync(user, role.ToString());
    }

    public async Task<IdentityResult> DeleteUserAsync(string identityId)
    {
        var user = await _userManager.FindByIdAsync(identityId);
        if(user == null)
        {
            return IdentityResult.Failed(new IdentityError()
            {
                Code= "User not found",
                Description = "User not found"
            });
        }
        return await _userManager.DeleteAsync(user);
    }

    public async Task<IdentityUser?> FindByIdAsync(string identityId)
    {
        return await _userManager.FindByIdAsync(identityId);
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(IdentityUser identityUser)
    {
        return await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
    }

    public async Task<Guid> GetUserIdAsync(string identityId, string role)
    {
        BaseUser? user = role switch
        {
            "Author" => await _authorRepository.GetByIdentityIdAsync(identityId),
            _ => null
        };

        return user is null ? Guid.Empty : user.Id;
    }

    public async Task<IdentityResult> UpdateUserAsync(IdentityUser user)
    {
        var userToUpdate = await _userManager.FindByIdAsync(user.Id);
        if(userToUpdate == null)
        {
            return IdentityResult.Failed(new IdentityError()
            {
                Code = "User not found",
                Description = "User not found"
            });
        }
        return await _userManager.UpdateAsync(user);
    }
}
