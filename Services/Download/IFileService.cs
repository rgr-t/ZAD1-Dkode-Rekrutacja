using MyApi.Models.Results;

namespace MyApi.Services.Download
{
    public interface IFileService
    {
        Task<FileDownloadResult> Download(string url);
        Task<FileSaveResult> Save(byte[] file, string fileName, string extension);
        
    }
}
