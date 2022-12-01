using MadaysBookShop.Controllers;
using MadaysBookShop.ViewModels;
using MadaysBookShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadaysBookShopTests.Controllers
{
    public class BookControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnsAllBooks()
        {
            // Arrange
            var mockBookRepository = RepositoryMocks.GetBookRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var bookController = new BookController(mockBookRepository.Object, mockCategoryRepository.Object);

            // Act
            var result = bookController.List("");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var bookListViewModel = Assert.IsAssignableFrom<BookListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(8, bookListViewModel.Books.Count());
        }
    }
}
