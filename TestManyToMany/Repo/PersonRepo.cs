using TestManyToMany.IRepo;
using TestManyToMany.Models;

namespace TestManyToMany.Repo
{
    public class PersonRepo : GenericRepo<Person>, IPersonRepo
    {
        public PersonRepo(AppDbContext context) : base(context)

        {
        }
    }
}
