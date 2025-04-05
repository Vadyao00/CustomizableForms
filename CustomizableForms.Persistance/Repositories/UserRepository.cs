using Contracts.IRepositories;
using CustomizableForms.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomizableForms.Persistance.Repositories;

public class UserRepository(CustomizableFormsContext dbContext) : RepositoryBase<User>(dbContext), IUserRepository
{
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var existingUser = await FindByCondition(u => u.Email == email, false).FirstOrDefaultAsync();

        return existingUser;
    }

    public void CreateUser(User user) => Create(user);

    public void DeleteUser(User user) => Delete(user);

    public void UpdateUser(User user) => Update(user);
}