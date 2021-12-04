using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.AddCntrollers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book{
                Id=1,
                Title="Brave New World",
                GenreId=1,
                PageCount=250,
                PublisDate= new DateTime(2021,01,01)
            },
            new Book{
                Id=2,
                Title="Homo Deus: A Brief History of Tomorrow",
                GenreId=2,
                PageCount=300,
                PublisDate= new DateTime(2021,01,01)
            },
            new Book{
                Id=3,
                Title="Dune",
                GenreId=3,
                PageCount=700,
                PublisDate= new DateTime(2021,01,01)
            },

        };
        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);

            if (book is not null)
                return BadRequest();
            BookList.Add(newBook);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublisDate = updatedBook.PublisDate != default ? updatedBook.PublisDate : book.PublisDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();
            BookList.Remove(book);
            return Ok();
        }

    }
}