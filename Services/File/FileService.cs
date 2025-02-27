using MyApi.Helpers.AppConfig;

namespace MyApi.Services.File
{
    //Class for working with files (download, read, save).
    //Decided to always use same neutral save/read path not to complicate much.
    public partial class FileService : IFileService
    {
        private readonly string _saveFolder;
        public FileService(IConfiguration configuration)
        {
            _saveFolder = AppConfigLoader.LoadFileSettings().SaveFolder;
        }
    }
}
