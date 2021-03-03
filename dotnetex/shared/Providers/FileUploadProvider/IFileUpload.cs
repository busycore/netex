using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace dotnetex.shared.Providers.FileUploadProvider
{
    public interface IFileUpload
    {
        Task<string> Upload(IFormFile arquivo);
    }
}