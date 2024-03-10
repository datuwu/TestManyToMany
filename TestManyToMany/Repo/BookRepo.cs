using TestManyToMany.IRepo;
using TestManyToMany.Models;

namespace TestManyToMany.Repo
{
    public class BookRepo : GenericRepo<Book>, IBookRepo
    {
        public BookRepo(AppDbContext context) : base(context)
        {
        }
    }
}
