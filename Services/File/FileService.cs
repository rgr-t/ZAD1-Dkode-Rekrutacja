using MyApi.Helpers.AppConfig;

namespace MyApi.Services.File
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
