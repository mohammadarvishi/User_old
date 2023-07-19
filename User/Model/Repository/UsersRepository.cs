using Microsoft.EntityFrameworkCore;
using Users.Model.UnitOfWork;
using Users.Model.ViewModels;

namespace Users.Model.Repository
{
    public class UsersRepository:IUsersRepository
    {
        private readonly UserDBContext _Context;
        private readonly IUnitOfWork _UW;
        public UsersRepository(IUnitOfWork UW)
        {

            _Context = UW.Context;
            _UW = UW;
        }

        public async Task<IEnumerable<UserDB>> FindAllAsync()
        {
            var result = await _Context.Users.ToListAsync();
            return result;
        }

        public async Task<UserDB> FindUserNameAsync(string UserName)
        {
            var result = await _Context.Users.FirstOrDefaultAsync(m => m.UserName == UserName);
            return result;
        }

        public async Task<UserDB> FindIdAsync(Guid id)
        {
            var result = await _Context.Users.FindAsync(id);
            return result;
        }


        public async Task<string> CreateAsync(UserViewModel userViewModel)
        {
            try
            {
                UserDB user = new()
                {
                    Name = userViewModel.Name,
                    Family = userViewModel.Family,
                    UserName = userViewModel.UserName,
                    Password = userViewModel.Password
                };
               await _Context.AddAsync(user);
                await _UW.Commit();
                return user.Id.ToString();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
        {
            var UserName = await FindUserNameAsync(loginViewModel.UserName);
            if (UserName != null)
            {
                if (UserName.Password == loginViewModel.Password)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;


        }
    }
}
