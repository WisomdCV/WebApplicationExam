using System;

namespace LAB08WILSONDCV.DTOs
{
    public class ClientInOrderDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
    
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public ClientInOrderDto Client { get; set; } = null!;
    }
}