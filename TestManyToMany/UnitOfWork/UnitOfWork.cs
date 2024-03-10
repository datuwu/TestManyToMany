using TestManyToMany.IRepo;
using TestManyToMany.Repo;

namespace TestManyToMany.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IBookRepo _bookRepo;
        private readonly IPersonRepo _personRepo;
        private readonly IPersonBookRepo _personBookRepo;

        public UnitOfWork(AppDbContext context, IBookRepo bookRepo, IPersonRepo personRepo, IPersonBookRepo personBookRepo)
        {
            _context = context;
            _bookRepo = bookRepo;
            _personRepo = personRepo;
            _personBookRepo = personBookRepo;
        }

        public IBookRepo BookRepo => _bookRepo;
        public IPersonRepo PersonRepo => _personRepo;
        public IPersonBookRepo PersonBookRepo => _personBookRepo;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
    
}
