namespace BookStoreAppMVC.Models
{
    public class ShoppingCart
          {
       public int Id { get; set; }
       public string UserId { get; set; }
       public List<CartItem> Items { get; set; } = new List<CartItem>();
       public double TotalPrice => Items.Sum(item => item.Product.Price * item.Quantity);
     }
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
