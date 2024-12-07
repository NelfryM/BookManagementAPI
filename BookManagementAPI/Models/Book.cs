namespace BookManagementAPI.Models
{
    public class Book
    {
        public int Id { get; set; } // Identificador único
        public string Title { get; set; } // Título del libro
        public string Author { get; set; } // Autor
        public string Genre { get; set; } // Género
        public int PublishedYear { get; set; } // Año de publicación
    }
}
