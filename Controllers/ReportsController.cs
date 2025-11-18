using System.Threading.Tasks;
using LAB08WILSONDCV.Services;
using Microsoft.AspNetCore.Mvc;

namespace LAB08WILSONDCV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("sales-by-client")]
        [ProducesResponseType(typeof(FileContentResult), 200)]
        [Produces("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        public async Task<IActionResult> GetSalesByClientReport()
        {
            var fileContents = await _reportService.GenerateSalesByClientReportAsync();
            var fileName = "VentasPorCliente.xlsx";
            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        [HttpGet("product-inventory")]
        [ProducesResponseType(typeof(FileContentResult), 200)]
        [Produces("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        public async Task<IActionResult> GetProductInventoryReport()
        {
            var fileContents = await _reportService.GenerateProductInventoryReportAsync();
            var fileName = "InventarioDeProductos.xlsx";
            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
