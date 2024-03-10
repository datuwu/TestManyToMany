using TestManyToMany.Models;

namespace TestManyToMany.Service
{
    public interface IBookService
    {
        Task AddAsync(Book book);
        Task<List<Book>> GetAsync();
        Task<Book> GetByIdAsync(int id);
        Task UpdateAsync(Book book);
    }
}
