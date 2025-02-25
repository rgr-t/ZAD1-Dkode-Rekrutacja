using MyApi.Models.Results;

namespace MyApi.Services.Download
{
    public partial class FileService
    {
        public async Task<FileSaveResult> Save(byte[] file, string fileName, string extension)
        {
            try
            {
                string saveFolderPath = GenerateSaveFolderPath();

                EnsureDirectoryExists(saveFolderPath);

                string fileNameWithExtension = $"{fileName}{extension}";
                string fullPath = Path.Combine(saveFolderPath, fileNameWithExtension);

                await File.WriteAllBytesAsync(fullPath, file);

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

        private string GenerateSaveFolderPath()
        {
            string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);            
            string saveFolderPath = Path.Combine(homePath, _saveFolder);

            return saveFolderPath;
        }

        private void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))            
                Directory.CreateDirectory(path);            
        }
    }
}