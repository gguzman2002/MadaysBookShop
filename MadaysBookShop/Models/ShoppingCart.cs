using Microsoft.EntityFrameworkCore;

namespace MadaysBookShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly MadaysBookShopDbContext _madaysBookShopDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public ShoppingCart(MadaysBookShopDbContext madaysBookShopDbContext)
        {
            _madaysBookShopDbContext = madaysBookShopDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            MadaysBookShopDbContext context = services.GetService<MadaysBookShopDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Book book)
        {
            var shoppingCartItem = _madaysBookShopDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Book.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Book = book,
                    Amount = 1
                };
                _madaysBookShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _madaysBookShopDbContext.SaveChanges();
        }

        public int RemoveFromCart(Book book)
        {
            var shoppingCartItem = _madaysBookShopDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Book.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _madaysBookShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _madaysBookShopDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                _madaysBookShopDbContext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Book)
                .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _madaysBookShopDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _madaysBookShopDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _madaysBookShopDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _madaysBookShopDbContext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Book.Price * c.Amount)
                .Sum();

            return total;
        }

    }
}
