using MadaysBookShop.Models;
using Microsoft.AspNetCore.Components;

namespace MadaysBookShop.Pages.App
{
    public partial class BookCard
    {
        [Parameter]
        public Book? Book { get; set; }
    }
}
