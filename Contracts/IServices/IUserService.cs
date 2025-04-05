using CustomizableForms.Domain.Entities;
using CustomizableForms.Domain.Responses;

namespace Contracts.IServices;

public interface IUserService
{
    Task<ApiBaseResponse> GetUserByEmailAsync(string email, User currentUser);
    
    Task<ApiBaseResponse> DeleteUserAsync(string email, User currentUser);
}