using MyApi.Models.Results.File;
using SystemFile = System.IO.File;

namespace MyApi.Services.File
{
    public partial class FileService
    {
        //File saving method, using file content byte array, filename and it's extension.
        public async Task<FileSaveResult> Save(byte[] file, string fileName, string extension)
        {
            if (file == null || file.Length == 0)
                return new FileSaveResult()
                {
                    Success = false,
                    Message = $"Failed to save file, it was null or empty."
                };

            try
            {
                string saveFolderPath = GenerateFilesFolderPath();

                Directory.CreateDirectory(saveFolderPath);

                string fileNameWithExtension = $"{fileName}{extension}";
                string fullPath = Path.Combine(saveFolderPath, fileNameWithExtension);

                await SystemFile.WriteAllBytesAsync(fullPath, file);

                return new FileSaveResult() 
                {
                    Success = true,
                    Message = $"Successfuly saved file to {fullPath}",
                    FilePath = fullPath,
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
    }
}