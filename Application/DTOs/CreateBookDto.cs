using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record CreateBookDto(
        string Title,
        string Author,
        string ISBN,
        int PublishedYear,
        int AvailableCopies
    );
}
