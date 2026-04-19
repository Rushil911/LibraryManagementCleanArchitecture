using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.DTOs;

namespace Application.Services
{
    public class BookService : IBookService
    {
        public readonly IBookRepository _bookRepository;

        public readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateBookDto book)
        {
            var bookEntity = _mapper.Map<Domain.Entities.Book>(book);

            await _bookRepository.AddAsync(bookEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            await _bookRepository.DeleteAsync(id);
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();

            return _mapper.Map<List<BookDto>>(books);
        }


        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return null;
            }
            return _mapper.Map<BookDto?>(book);
        }

        public async Task UpdateAsync(UpdateBookDto book)
        {
            var bookEntity = _mapper.Map<Domain.Entities.Book>(book);
            await _bookRepository.UpdateAsync(bookEntity);
        }
    }
}
