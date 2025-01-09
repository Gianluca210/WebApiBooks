using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiBooks.models;

namespace webApiBooks.Controllers {
    [Route("api/Authors")]
    [ApiController]
    public class AuthorsController : Controller {
        private readonly DefaultDbContext _context;

        public AuthorsController(DefaultDbContext context) {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAuthors(Authors authors) {
            await _context.Authors.AddAsync(authors);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("List")]
        public async Task<ActionResult<IEnumerable<Books>>> ListAuthors() {
            var Authors = await _context.Authors.ToListAsync();

            return Ok(Authors);
        }

        [HttpGet]
        [Route("See")]
        public async Task<IActionResult> SeeAuthors(int Id) {
            Authors authors = await _context.Authors.FindAsync(Id);

            if (authors == null) {
                return NotFound();
            }
            return Ok(authors);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditAuthors(int Id, Authors authors) {
            var ExistingAuthors = await _context.Authors.FindAsync(Id);

            ExistingAuthors!.Name = authors.Name;
            ExistingAuthors.LastName = authors.LastName;
            ExistingAuthors.RegisterDate = authors.RegisterDate;
            ExistingAuthors.Birthdate = authors.Birthdate;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAuthors(int Id) {
            var DeleteAuthor = await _context.Authors.FindAsync(Id);
            _context.Authors.Remove(DeleteAuthor!);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
