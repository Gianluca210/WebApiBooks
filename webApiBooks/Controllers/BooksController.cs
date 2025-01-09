using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiBooks.dto;
using webApiBooks.models;

namespace webApiBooks.Controllers { 
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase {
        private readonly DefaultDbContext _context;

        public BooksController(DefaultDbContext context) {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateBook(Books books) {
            await _context.Books.AddAsync(books);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("List")]
        public async Task<ActionResult<IEnumerable<Books>>>ListBooks() {
            var Books = await _context.Books.ToListAsync();

            return Ok(Books);
        }

        [HttpGet]
        [Route("See")]
        public async Task<IActionResult>SeeBooks(int Id) {
            Books books = await _context.Books.FindAsync(Id);
            if (books == null) {
                return NotFound();
            }
            Authors author = await _context.Authors.FindAsync(books.IdAuthor);

            if (author == null) {
                return NotFound();
            }
            var dto = new BooksDto() { Id = Id, IdAuthor = author.Id, Description = books.Description, PublishDate = books.PublishDate, Title = books.Title, NombreDelAutor = author.Name};
            return Ok(dto);

        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult>EditBooks(int Id, Books books) {
            var ExistingBook = await _context.Books.FindAsync(Id);

            ExistingBook!.Title = books.Title;
            ExistingBook.PublishDate = books.PublishDate;
            ExistingBook.Description = books.Description;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult>DeleteBooks(int Id) {
            var DeleteBook = await _context.Books.FindAsync(Id);
            _context.Books.Remove(DeleteBook!);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
