using MyApi.Helpers;

namespace MyApi.Services.Download
{
    public partial class FileService : IFileService
    {
        private readonly string _saveFolder;
        public FileService(IConfiguration configuration)
        {
            _saveFolder = AppConfigLoader.LoadFileSettings().SaveFolder;
        }
    }
}
