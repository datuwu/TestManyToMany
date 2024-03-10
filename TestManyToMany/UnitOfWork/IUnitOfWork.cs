using TestManyToMany.IRepo;
using TestManyToMany.Repo;

namespace TestManyToMany.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBookRepo BookRepo { get; }
        IPersonRepo PersonRepo { get; }
        IPersonBookRepo PersonBookRepo { get; }
        public Task<int> SaveChangesAsync();
    }
}
