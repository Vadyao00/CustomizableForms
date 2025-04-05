using Contracts.IRepositories;
using Contracts.IServices;
using CustomizableForms.Domain.Entities;
using CustomizableForms.Domain.Responses;

namespace CustomizableForms.Application.Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;

    public UserService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<ApiBaseResponse> GetUserByEmailAsync(string email, User currentUser)
    {
        if (!CheckUser(currentUser))
            return new BadUserBadRequestResponse();
        
        var existingUser = await _repositoryManager.User.GetUserByEmailAsync(email);

        if (existingUser == null)
        {
            return new InvalidEmailBadRequestResponse();
        }
        
        return new ApiOkResponse<User>(existingUser);
    }

    public async Task<ApiBaseResponse> DeleteUserAsync(string email, User currentUser)
    {
        if (!CheckUser(currentUser))
            return new BadUserBadRequestResponse();
        
        var user = await _repositoryManager.User.GetUserByEmailAsync(email);
        if (user != null)
        {
            _repositoryManager.User.DeleteUser(user);
            await _repositoryManager.SaveAsync();
        }
        else
        {
            return new InvalidEmailBadRequestResponse();
        }

        return new ApiOkResponse<User>(user);
    }
    
    private bool CheckUser(User? user)
    {
        if (user == null)
        {
            return false;
        }

        return true;
    }
}