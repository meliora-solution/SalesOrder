namespace DataLayer.Entity
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}