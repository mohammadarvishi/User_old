using Users.Model.ViewModels;

namespace Users.Services
{
    public interface ICreateToken
    {
        Task<TokenViewModel> Token(string username);
    }
}
