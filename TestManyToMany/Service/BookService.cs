using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestManyToMany.Models;
using TestManyToMany.UnitOfWork;

namespace TestManyToMany.Service
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Book book)
        {
            _unitOfWork.BookRepo.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAsync()
        {
            return await _unitOfWork.BookRepo.GetAllAsync(include: x => x.Include(x => x.PersonBooks).ThenInclude(x => x.Person));
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _unitOfWork.BookRepo.GetByIdAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            var existingBook = _unitOfWork.BookRepo.GetAllAsync(include: x => x.Include(x => x.PersonBooks), filter: x => x.Id == book.Id).Result.FirstOrDefault();

            _unitOfWork.PersonBookRepo.RemoveRange(existingBook.PersonBooks.ToList());

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, Book>());
            var mapper = config.CreateMapper();
            var updatedBook = mapper.Map(book, existingBook);


            _unitOfWork.BookRepo.Update(updatedBook);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
