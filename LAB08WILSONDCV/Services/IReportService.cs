using System.Threading.Tasks;

namespace LAB08WILSONDCV.Services
{
    public interface IReportService
    {
        Task<byte[]> GenerateSalesByClientReportAsync();
        Task<byte[]> GenerateProductInventoryReportAsync();
    }
}
