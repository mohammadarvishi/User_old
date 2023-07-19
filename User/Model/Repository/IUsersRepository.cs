using Users.Model.ViewModels;

namespace Users.Model.Repository
{
    public interface IUsersRepository
    {
        Task<IEnumerable<UserDB>> FindAllAsync();
        Task<string> CreateAsync(UserViewModel userViewModel);
        Task<bool> LoginAsync(LoginViewModel loginViewModel);
        Task<UserDB> FindUserNameAsync(string UserName);
        Task<UserDB> FindIdAsync(Guid id);
    }
}
