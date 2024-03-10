using TestManyToMany.IRepo;
using TestManyToMany.Models;

namespace TestManyToMany.Repo
{
    public class PersonBookRepo : GenericRepo<PersonBook>, IPersonBookRepo
    {
        public PersonBookRepo(AppDbContext context) : base(context)
        {
        }
    }
}
