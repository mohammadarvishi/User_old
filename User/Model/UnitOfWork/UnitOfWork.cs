using Users.Model.Repository;

namespace Users.Model.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UserDBContext Context { get; }
        private IUsersRepository _IUsersRepository;
        public UnitOfWork(UserDBContext Contex)
        {
            Context = Contex;
        }

        public IUsersRepository UsersRepository
        {
            get
            {
                if (_IUsersRepository == null)
                {
                    _IUsersRepository = new UsersRepository(this);
                }

                return _IUsersRepository;
            }
        }

        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }
    }
}
