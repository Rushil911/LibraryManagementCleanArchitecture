using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(CreateBookDto book);
        Task UpdateAsync(UpdateBookDto book);
    }
}
