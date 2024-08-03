using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Data.Repositories;
using Moq;
using Xunit;

namespace Hackathon.Tests.Services
{
    [Collection("PatientService")]
    public class PatientServiceTest
    {
        private readonly Mock<IPatientRepository> _patientRepository;
      
        public PatientServiceTest()
        {
            _patientRepository = new Mock<IPatientRepository>();        
        }


       /* [Fact]
        public async Task Add_WhenCalled_ReturnsBook()
        {
            // Arrange
            _genreRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new Genre("Genre", "Genre Description"));
            var bookService = new BookService(_bookRepository.Object, _genreRepository.Object);
            var bookRequestDto = new BookRequestDto("Book one", "Someone", 1);

            // Act
            var result = await bookService.Add(bookRequestDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bookRequestDto.Title, result.Title);
            Assert.Equal(bookRequestDto.Author, result.Author);
            Assert.Equal(bookRequestDto.GenreId, result.GenreId);
        }

        [Fact]
        public async Task GetAll_WhenCalled_ReturnsBooks()
        {
            // Arrange
            var bookService = new BookService(_bookRepository.Object, _genreRepository.Object);
            var books = new List<Book>
            {
                new("Book one", "Someone", 1),
                new("Book two", "Someone else", 2)
            };

            _bookRepository.Setup(x => x.GetAll()).ReturnsAsync(books);

            // Act
            var result = await bookService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(books.Count, result.Count());
        }

        [Fact]
        public async Task GetByGenre_WhenCalled_ReturnsBooks()
        {
            // Arrange
            var bookService = new BookService(_bookRepository.Object, _genreRepository.Object);
            var books = new List<Book>
            {
                new("Book one", "Someone", 1),
                new("Book two", "Someone else", 1)
            };
            _bookRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Book, bool>>>())).ReturnsAsync(books);

            // Act
            var result = await bookService.GetByGenre(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(books.Count, result.Count());
        }

        [Fact]
        public async Task GetById_WhenCalled_ReturnsBook()
        {
            // Arrange
            var bookService = new BookService(_bookRepository.Object, _genreRepository.Object);
            var book = new Book("Book one", "Someone", 1);
            _bookRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(book);

            // Act
            var result = await bookService.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(book.Title, result.Title);
            Assert.Equal(book.Author, result.Author);
            Assert.Equal(book.GenreId, result.GenreId);
        }

        [Fact]
        public async Task Remove_WhenCalled_ReturnsVoid()
        {
            // Arrange
            var bookService = new BookService(_bookRepository.Object, _genreRepository.Object);
            var book = new Book("Book one", "Someone", 1);
            _bookRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(book);

            // Act
            await bookService.Remove(1);

            // Assert
            _bookRepository.Verify(x => x.Delete(It.IsAny<Book>()), Times.Once);
        }

        [Fact]
        public async Task Update_WhenCalled_ReturnsVoid()
        {
            // Arrange
            var book = new Book("Book one", "Someone", 1);
            _bookRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(book);
            var bookService = new BookService(_bookRepository.Object, _genreRepository.Object);

            // Act
            await bookService.Update(book);

            // Assert
            _bookRepository.Verify(x => x.Update(It.IsAny<Book>()), Times.Once);
        }*/
    }
}
