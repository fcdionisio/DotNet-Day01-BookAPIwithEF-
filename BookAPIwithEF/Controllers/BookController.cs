using System.Net;
using BookAPIwithEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPIwithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookContext bookContext;
        public BookController()
        {
            bookContext = new BookContext();
        }

        [HttpGet]
        [Route("ListAll")]
        [Route("All")]
        [Route("ShowAll")]
        public List<Book> ViewAllBooks()
        {
            return bookContext.Books.ToList<Book>();
        }

        [HttpPost]
        [Route("Save")]
        public ActionResult<Book> SaveBook(Book newBook)
        {
            try
            {
                bookContext.Books.Add(newBook);
                bookContext.SaveChanges();
                return Ok(newBook);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            

        }

        [HttpDelete]
        [Route("Delete/{BookId:int:min(1)}")]
        public bool DeleteBook(int BookId)
        {
            var book = bookContext.Books.FirstOrDefault(x => x.BookId == BookId);
            try
            {
                if (book != null)
                {
                    bookContext.Books.Remove(book);
                    bookContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return false;
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult<Book> UpdateBook(Book newBook)
        {
            try
            {
                if (newBook != null)
                {
                    bookContext.Books.Update(newBook);
                    bookContext.SaveChanges();
                    return Ok(newBook);
                }
            }
            catch
            {
                return NotFound();
            }
            return NotFound();
        }

        [HttpGet]
        [Route("DisplayByBookName/{Name:alpha}")]

        public List<Book> DisplayBookByName(string Name)
        {
            var books = bookContext.Books.Where(c => c.Name.ToLower().Contains(Name.ToLower())).ToList();

            return books;
        }

        [HttpGet]
        [Route("DisplayByBookAgeLimit/{AgeLimit:int:range(1,100)}")]

        public List<Book> DisplayBookByAge(int AgeLimit)
        {
            var books = bookContext.Books.Where(b => b.AgeLimit <= AgeLimit).ToList();

            return books;
        }

        [HttpGet]
        [Route("DisplayByPrice/{price:double:range(100,10000)}")]

        public List<Book> DisplayBookByPrice(double price)
        {
            var books = bookContext.Books.Where(b=>b.Price <= price).ToList();

            return books;
        }



    }
}