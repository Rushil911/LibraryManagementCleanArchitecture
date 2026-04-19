using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBookRepository
    {
        Task <List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
    }
}
