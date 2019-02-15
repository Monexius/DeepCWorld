using System.Threading.Tasks;
namespace DeepSeaWorldApp.Services
{
    public interface QrScanningService
    {
        Task<string> ScanAsync();
    }
}
