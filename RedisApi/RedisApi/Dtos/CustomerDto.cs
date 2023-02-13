namespace RedisApi.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleInitial { get; set; }
        public string LastName { get; set; } = null!;
    }
}
