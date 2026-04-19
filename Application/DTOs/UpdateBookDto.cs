using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record UpdateBookDto(
        string Title,
        string Author,
        string ISBN,
        int PublishedYear,
        int AvailableCopies
    );
}
