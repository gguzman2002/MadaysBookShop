using MadaysBookShop.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MadaysBookShopTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IBookRepository> GetBookRepository()
        {
            var books = new List<Book>
            {
                new Book
                {
                    Name = "Winston and James Talk Life Over Coffee",
                    Price = 14.95M,
                    ShortDescription = "Sit amet cursus sit amet dictum sit amet justo donec enim diam vulputate ut pharetra sit amet aliquam id diam.",
                    LongDescription = "Leo duis ut diam quam nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris.",
                    Category = Categories["Comedy"],
                    ImageUrl = "/images/birds-coffee-shop.png",
                    InStock = true,
                    IsBookOfTheWeek = false,
                    ImageThumbnailUrl = "/images/birds-coffee-shop-thumb.png"
                },
                new Book
                {
                    Name = "You Had Me At Bark",
                    Price = 14.95M,
                    ShortDescription = "Sit amet cursus sit amet dictum sit amet justo donec enim diam vulputate ut pharetra sit amet aliquam id diam.",
                    LongDescription = "Leo duis ut diam quam nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris.",
                    Category = Categories["Romance"],
                    ImageUrl = "/images/dog-friends.png",
                    InStock = true,
                    IsBookOfTheWeek = false,
                    ImageThumbnailUrl = "/images/dog-friends-thumb.png"
                },
                new Book
                {
                    Name = "Tiny the Elephant Saves the Woods!",
                    Price = 14.95M,
                    ShortDescription = "Sit amet cursus sit amet dictum sit amet justo donec enim diam vulputate ut pharetra sit amet aliquam id diam.",
                    LongDescription = "Leo duis ut diam quam nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris.",
                    Category = Categories["Adventure"],
                    ImageUrl = "/images/elephant-with-friends.png",
                    InStock = true,
                    IsBookOfTheWeek = false,
                    ImageThumbnailUrl = "/images/elephant-with-friends-thumb.png"
                },
                new Book
                {
                    Name = "The Adventures of Pretty Baby",
                    Price = 14.95M,
                    ShortDescription = "Sit amet cursus sit amet dictum sit amet justo donec enim diam vulputate ut pharetra sit amet aliquam id diam.",
                    LongDescription = "Leo duis ut diam quam nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris.",
                    Category = Categories["Adventure"],
                    ImageUrl = "/images/happy-bird-in-woods.png",
                    InStock = true,
                    IsBookOfTheWeek = false,
                    ImageThumbnailUrl = "/images/happy-bird-in-woods-thumb.png"
                },
                new Book
                {
                    Name = "Space - As Told by Bartholomew the Mouse",
                    Price = 14.95M,
                    ShortDescription = "Sit amet cursus sit amet dictum sit amet justo donec enim diam vulputate ut pharetra sit amet aliquam id diam.",
                    LongDescription = "Leo duis ut diam quam nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris.",
                    Category = Categories["Comedy"],
                    ImageUrl = "/images/mouse-in-stars.png",
                    InStock = true,
                    IsBookOfTheWeek = false,
                    ImageThumbnailUrl = "/images/mouse-in-stars-thumb.png"
                },
                new Book
                {
                    Name = "Starkey and the Princess of the Moon",
                    Price = 14.95M,
                    ShortDescription = "Sit amet cursus sit amet dictum sit amet justo donec enim diam vulputate ut pharetra sit amet aliquam id diam.",
                    LongDescription = "Leo duis ut diam quam nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris.",
                    Category = Categories["Romance"],
                    ImageUrl = "/images/sailing-snail.png",
                    InStock = true,
                    IsBookOfTheWeek = false,
                    ImageThumbnailUrl = "/images/sailing-snail-thumb.png"
                },
                new Book
                {
                    Name = "Mr. Rufus - Attorney At Law",
                    Price = 14.95M,
                    ShortDescription = "Sit amet cursus sit amet dictum sit amet justo donec enim diam vulputate ut pharetra sit amet aliquam id diam.",
                    LongDescription = "Leo duis ut diam quam nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris.",
                    Category = Categories["Adventure"],
                    ImageUrl = "/images/van-gogh-dog.png",
                    InStock = true,
                    IsBookOfTheWeek = false,
                    ImageThumbnailUrl = "/images/van-gogh-dog-thumb.png"
                },
                new Book
                {
                    Name = "Sam with Friends",
                    Price = 14.95M,
                    ShortDescription = "Sit amet cursus sit amet dictum sit amet justo donec enim diam vulputate ut pharetra sit amet aliquam id diam.",
                    LongDescription = "Leo duis ut diam quam nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris.",
                    Category = Categories["Adventure"],
                    ImageUrl = "/images/walrus-eating-pizza.png",
                    InStock = true,
                    IsBookOfTheWeek = false,
                    ImageThumbnailUrl = "/images/walrus-eating-pizza-thumb.png"
                }
            };

            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(repo => repo.AllBooks).Returns(books);
            mockBookRepository.Setup(repo => repo.BooksOfTheWeek).Returns(books.Where(b => b.IsBookOfTheWeek));
            mockBookRepository.Setup(repo => repo.GetBookById(It.IsAny<int>())).Returns(books[0]);

            return mockBookRepository;
        }

        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Adventure",
                    Description = "Lorem Ipsum"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Romance",
                    Description = "Lorem Ipsum"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Comedy",
                    Description = "Lorem Ipsum"
                }
            };

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.AllCategories).Returns(categories);

            return mockCategoryRepository;
        }

        private static Dictionary<string, Category>? _categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Adventure" },
                        new Category { CategoryName = "Romance" },
                        new Category { CategoryName = "Comedy" }
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach (var genre in genresList)
                    {
                        _categories.Add(genre.CategoryName, genre);
                    }
                }

                return _categories;
            }
        }
    }
}
