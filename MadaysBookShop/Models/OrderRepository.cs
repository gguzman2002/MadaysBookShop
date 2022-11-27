namespace MadaysBookShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MadaysBookShopDbContext _madaysBookShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(MadaysBookShopDbContext madaysBookShopDbContext, IShoppingCart shoppingCart)
        {
            _madaysBookShopDbContext = madaysBookShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    BookId = shoppingCartItem.Book.BookId,
                    Price = shoppingCartItem.Book.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _madaysBookShopDbContext.Orders.Add(order);

            _madaysBookShopDbContext.SaveChanges();
        }
    }
}
