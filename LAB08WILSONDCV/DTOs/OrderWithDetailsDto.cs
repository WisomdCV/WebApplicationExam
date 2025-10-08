using System;
using System.Collections.Generic;

namespace LAB08WILSONDCV.DTOs
{
    public class OrderWithDetailsDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public ClientInOrderDto Client { get; set; }
        public List<ProductDetailDto> Details { get; set; }
    }
}