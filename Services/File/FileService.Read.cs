using MyApi.Models.Results.File;
using SystemFile = System.IO.File;

namespace MyApi.Services.File
{
    public partial class FileService
    {
        public async Task<FileReadResult> Read(string fileName, string extension)
        {
            var filesPath = GenerateFilesFolderPath();
            var fullFilePath = $"{filesPath}\\{fileName}{extension}";

            if (!SystemFile.Exists(fullFilePath))
            {
                return new FileReadResult()
                {
                    Success = false,
                    Message = $"File {fileName}{extension} in {filesPath} does not exist."
                };
            }

            try
            {
                var fileContent = await SystemFile.ReadAllBytesAsync(fullFilePath);

                if (fileContent == null || fileContent.Length == 0)
                {
                    return new FileReadResult()
                    {
                        Success = false,
                        Message = $"File {fileName}{extension} in {filesPath} is empty."
                    };
                }


                return new FileReadResult()
                {
                    Success = true,
                    Message = $"Successfully read {fileName}{extension} in {filesPath}.",
                    FileContent = fileContent,
                };

            }
            catch(Exception ex)
            {

                return new FileReadResult()
                {
                    Success = false,
                    Message = $"Failed to read {fileName}{extension} in {filesPath}. Error: {ex.Message}"
                };
            }
        }
    }
}
