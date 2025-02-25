using MyApi.Models.Results.File;
using SystemFile = System.IO.File;

namespace MyApi.Services.File
{
    public partial class FileService
    {
        public async Task<FileSaveResult> Save(byte[] file, string fileName, string extension)
        {
            try
            {
                string saveFolderPath = GenerateFilesFolderPath();

                EnsureDirectoryExists(saveFolderPath);

                string fileNameWithExtension = $"{fileName}{extension}";
                string fullPath = Path.Combine(saveFolderPath, fileNameWithExtension);

                await SystemFile.WriteAllBytesAsync(fullPath, file);

                return new FileSaveResult() 
                {
                    Success = true,
                    Message = $"Successfuly saved file.",
                    FilePath = saveFolderPath,
                    FileName = fileName,
                    FileExtension = extension
                };
            }
            catch (IOException ex)
            {
                return new FileSaveResult()
                {
                    Success = false,
                    Message = $"IO error: {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                return new FileSaveResult()
                {
                    Success = false,
                    Message = $"Unexpected error: {ex.Message}"
                };
            }
        }

        private void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))            
                Directory.CreateDirectory(path);            
        }
    }
}