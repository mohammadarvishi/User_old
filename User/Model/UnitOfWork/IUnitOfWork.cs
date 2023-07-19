using Users.Model.Repository;

namespace Users.Model.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Commit();
        UserDBContext Context { get; }
        IUsersRepository UsersRepository { get; }
    }
}
