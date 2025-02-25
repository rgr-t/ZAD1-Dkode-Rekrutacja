using MyApi.Models.Results.File;

namespace MyApi.Services.File
{
    public interface IFileService
    {
        Task<FileDownloadResult> Download(string url);
        Task<FileSaveResult> Save(byte[] file, string fileName, string extension);
        Task<FileReadResult> Read(string fileName, string extension);
        string GenerateFilesFolderPath();
    }
}
