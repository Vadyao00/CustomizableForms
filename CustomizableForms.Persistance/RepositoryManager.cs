using Contracts.IRepositories;
using CustomizableForms.Persistance.Repositories;

namespace CustomizableForms.Persistance;

public class RepositoryManager : IRepositoryManager
{
    private readonly CustomizableFormsContext _userManagementContext;
    private readonly Lazy<IUserRepository> _userRepository;

    public RepositoryManager(CustomizableFormsContext userManagementContext)
    {
        _userManagementContext = userManagementContext;
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(userManagementContext));
    }

    public IUserRepository User => _userRepository.Value;
    
    public async Task SaveAsync() => await _userManagementContext.SaveChangesAsync();
}