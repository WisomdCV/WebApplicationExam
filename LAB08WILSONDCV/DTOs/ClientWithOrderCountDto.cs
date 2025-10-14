namespace LAB08WILSONDCV.DTOs
{
    public class ClientWithOrderCountDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int OrderCount { get; set; }
    }
}