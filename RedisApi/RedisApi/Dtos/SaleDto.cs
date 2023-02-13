namespace RedisApi.Dtos
{
    public class SaleDto
    {
        public int SalesId { get; set; }
        public string Seller { get; set; }
        public string Customer { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal Total { get; set; }
    }
}
