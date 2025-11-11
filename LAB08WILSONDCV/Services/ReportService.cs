using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using LAB08WILSONDCV.Interfaces;

namespace LAB08WILSONDCV.Services
{
    public class ReportService : IReportService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;

        public ReportService(IClientRepository clientRepository, IProductRepository productRepository)
        {
            _clientRepository = clientRepository;
            _productRepository = productRepository;
        }

        public async Task<byte[]> GenerateSalesByClientReportAsync()
        {
            var salesData = await _clientRepository.GetTotalSalesByClientAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Ventas por Cliente");
                
                // Headers
                worksheet.Cell(1, 1).Value = "Nombre del Cliente";
                worksheet.Cell(1, 2).Value = "Total de Ventas";
                
                // Data
                var dataForTable = salesData.Select((item, index) => new
                {
                    ClientName = item.ClientName,
                    TotalSales = item.TotalSales
                });
                worksheet.Cell(2, 1).InsertData(dataForTable);

                // Format as Table only if there is data
                var range = worksheet.RangeUsed();
                if (range != null && range.RowCount() > 1)
                {
                    var table = range.CreateTable();
                    table.Theme = XLTableTheme.TableStyleMedium9; // Blue theme
                }

                // Apply currency format to the sales column
                worksheet.Column(2).Style.NumberFormat.Format = "\"$\"#,##0.00";
                
                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        public async Task<byte[]> GenerateProductInventoryReportAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Inventario de Productos");

                // Headers
                worksheet.Cell(1, 1).Value = "ID Producto";
                worksheet.Cell(1, 2).Value = "Nombre";
                worksheet.Cell(1, 3).Value = "Precio";
                
                // Data
                var dataForTable = products.Select((product, index) => new
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price
                });
                worksheet.Cell(2, 1).InsertData(dataForTable);

                // Format as Table only if there is data
                var range = worksheet.RangeUsed();
                if (range != null && range.RowCount() > 1)
                {
                    var table = range.CreateTable();
                    table.Theme = XLTableTheme.TableStyleMedium2; // Green theme
                }

                // Apply currency format to the price column
                worksheet.Column(3).Style.NumberFormat.Format = "\"$\"#,##0.00";

                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}