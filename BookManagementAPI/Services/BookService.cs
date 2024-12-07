using BookManagementAPI.Models;

namespace BookManagementAPI.Services
{
    public class BookService
    {
        private readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "El Quijote", Author = "Miguel de Cervantes", Genre = "Novela", PublishedYear = 1605 },
            new Book { Id = 2, Title = "Cien años de soledad", Author = "Gabriel García Márquez", Genre = "Realismo mágico", PublishedYear = 1967 }
        };

        public List<Book> GetAll() => _books;

        public Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void Add(Book book)
        {
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }

        public bool Update(int id, Book updatedBook)
        {
            var book = GetById(id);
            if (book == null) return false;

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Genre = updatedBook.Genre;
            book.PublishedYear = updatedBook.PublishedYear;

            return true;
        }

        public bool Delete(int id)
        {
            var book = GetById(id);
            if (book == null) return false;

            _books.Remove(book);
            return true;
        }
    }
}